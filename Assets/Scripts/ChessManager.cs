using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GoogleCloudStreamingSpeechToText;
using Photon.Pun;

public class ChessManager : MonoBehaviour
{

    /* ChessManager's responsibilities:
        1. Parse user input from microphone
        2. Move piece to corresponding coordinates from user command
        3. Manage turns
        4. Update board map
     */
    public StreamingRecognizer sr;
    public float pieceVerticalDist = 0.15f;
    public float pieceVertSpeed = 5f;
    public float pieceHoriSpeed = 5f;

    Photon.Voice
    float oldY;
    private List<ChessPiece> pieces;
    private bool blackTurn, success;
    private string newPiecePosition;
    private ChessPiece currPiece;

    private void Start()
    {
        pieces = new List<ChessPiece>();
        foreach (GameObject piece in GameObject.FindGameObjectsWithTag("Chess Pieces"))
        {
            ChessPiece p = piece.GetComponent<ChessPiece>();
            //Debug.Log("Adding the " + p.color.ToString() + " " + p.rank.ToString() + " located at " + p.position);
            pieces.Add(piece.GetComponent<ChessPiece>());
        }
    }

    private void Update()
    {
        ChessPiece heldPiece = null;
        foreach (ChessPiece piece in pieces)
        {
            if (piece.held == true)
            {
                heldPiece = piece;
                if (!sr.IsListening())
                {
                    Debug.Log("This message should only print once!");
                    StartCoroutine(ListenToUser());
                }
            }
            //else sr.StopListening();
        }

        if (success && heldPiece != null)
        {
            MovePiece(heldPiece, newPiecePosition);
        }
        
    }

    IEnumerator ListenToUser()
    {
        sr.StartListening();
        yield return new WaitForSeconds(1);
        Debug.Log("5...");
        yield return new WaitForSeconds(1);
        Debug.Log("4...");
        yield return new WaitForSeconds(1);
        Debug.Log("3...");
        yield return new WaitForSeconds(1);
        Debug.Log("2...");
        yield return new WaitForSeconds(1);
        Debug.Log("1...");
        sr.StopListening();
    }

    public void DebugMsg(string msg)
    {
        Debug.Log("Message: " + msg);
    }

    public void ParseUserCommand(string command)
    {
        Debug.Log("Here's what you said: " + sr.finalResult);
        string[] keyPhrases = new string[64]{
            "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8",
            "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8",
            "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8",
            "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8",
            "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8",
            "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8",
            "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8",
            "H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8",};

        for (int i = 0; i < 64; i++)
        {
            if (sr.finalResult.Contains(keyPhrases[i]))
            {
                newPiecePosition = keyPhrases[i];
                success = true;
                break;
            }
        }

/*        foreach(string pos in keyPhrases)
        {
            if (command.Contains(pos)) {
                newPiecePosition = pos;
                success = true;
                break;
            }
        }*/
    }

    public void MovePiece(ChessPiece piece, string pos)
    {
        if ((blackTurn && piece.color == ChessPiece.Color.BLACK) || (!blackTurn && piece.color == ChessPiece.Color.WHITE) && piece.held)
        {
            // Attach player to piece, disable movement controls
            /*
            currPiece = piece;
            Vector3 pPos = piece.piece.transform.position;
            oldY = pPos.y;
            // Go up
            piece.piece.transform.position = new Vector3(pPos.x, Mathf.MoveTowards(pPos.y, pieceVerticalDist, pieceVertSpeed * Time.deltaTime), pPos.z);

            */
            piece.piece.transform.position = new Vector3(piece.piece.transform.position.x, Mathf.MoveTowards(piece.piece.transform.position.y, 0.5f, pieceVertSpeed * Time.deltaTime), piece.piece.transform.position.z);
            StartCoroutine(MoveDown(piece, pos));
        }
    }

    IEnumerator MoveHorizontally(ChessPiece piece, string pos)
    {
        Vector3 posB = GameObject.Find(pos).transform.position;
        piece.piece.transform.position = new Vector3(Mathf.MoveTowards(piece.piece.transform.position.x, posB.x, 5 * Time.deltaTime), piece.piece.transform.position.y, Mathf.MoveTowards(piece.piece.transform.position.z, posB.z, 5 * Time.deltaTime));
        success = false;
        yield return new WaitForSeconds(1f);
    }

    IEnumerator MoveDown(ChessPiece piece, string pos)
    {/*
        Vector3 pPos = currPiece.piece.transform.position;
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(MoveHorizontally(pos));
        currPiece.piece.transform.position = new Vector3(pPos.x, Mathf.MoveTowards(oldY, pieceVerticalDist, pieceVertSpeed * Time.deltaTime), pPos.z);

        // Release player from chess piece, enable movement controls
        */
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(MoveHorizontally(piece, pos));
        piece.piece.transform.position = new Vector3(piece.piece.transform.position.x, Mathf.MoveTowards(piece.piece.transform.position.y, 0.15f, 5 * Time.deltaTime), piece.piece.transform.position.z);
        blackTurn = !blackTurn;

        /*
        if (currPiece.piece.transform.position == new Vector3(pPos.x, oldY, pPos.z))
        {
            Debug.Log("Done!");
            success = false;
        }
        */
    }
}
