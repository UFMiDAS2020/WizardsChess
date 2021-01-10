using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessManager : MonoBehaviour
{

    /* ChessManager's responsibilities:
        1. Parse user input from microphone
        2. Move piece to corresponding coordinates from user command
        3. Manage turns
        4. Update board map
     */

    public float pieceVerticalDist = 0.15f;
    public float pieceVertSpeed = 5f;
    public float pieceHoriSpeed = 5f;

    private bool blackTurn;
        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePiece(ChessPiece piece, string pos)
    {
        if ((blackTurn && piece.color == ChessPiece.Color.BLACK) || (!blackTurn && piece.color == ChessPiece.Color.WHITE) && piece.held)
        {
            Vector3 pPos = piece.piece.transform.position;
            piece.piece.transform.position = new Vector3(pPos.x, Mathf.MoveTowards(pPos.y, 0.5f, pieceVertSpeed * Time.deltaTime), pPos.z);
            StartCoroutine(MoveDown(piece, pos));
        }
    }

    IEnumerator MoveDown(ChessPiece piece, string pos)
    {
        Vector3 pPos = piece.piece.transform.position;
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(MoveHorizontally(piece, pos));
        piece.piece.transform.position = new Vector3(pPos.x, Mathf.MoveTowards(pPos.y, pieceVerticalDist, pieceVertSpeed * Time.deltaTime), pPos.z);
    }

    IEnumerator MoveHorizontally(ChessPiece piece, string pos)
    {
        Vector3 posB = GameObject.Find(pos).transform.position;
        Vector3 pPos = piece.piece.transform.position;
        piece.piece.transform.position = new Vector3(Mathf.MoveTowards(pPos.x, posB.x, pieceHoriSpeed * Time.deltaTime), pPos.y, Mathf.MoveTowards(pPos.z, posB.z, pieceHoriSpeed * Time.deltaTime));
        blackTurn = !blackTurn;
        yield return new WaitForSeconds(1f);
    }
}
