using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    /*
    public float tileLength;
    List<ChessPiece> pieces;

    // Start is called before the first frame update
    void Start()
    {
        pieces = new List<ChessPiece>();
        foreach (GameObject piece in GameObject.FindGameObjectsWithTag("Chess Pieces")) {
            ChessPiece p = piece.GetComponent<ChessPiece>();
            Debug.Log("Adding the " + p.color.ToString() + " " + p.rank.ToString() + " located at " + p.position);
            pieces.Add(piece.GetComponent<ChessPiece>());
        }
    }

    List<string> CalculatePawnMoves(ChessPiece pawn)
    {
        if (pawn.rank != ChessPiece.Rank.PAWN) throw new System.ArgumentException();
        bool black = pawn.color == ChessPiece.Color.BLACK;
        int layerMask = black ? 1 << 8 : 1 << 9;

        Vector2 coords = pawn.coordinates;
        if ((coords.x == 1 && !black)||(coords.y == 6 && black))
        {
            // Try to see if we can go two steps forward
        }

        List<string> possibleMoves = new List<string>();
        return possibleMoves;
    }

    List<string> CalculateQueenMoves(ChessPiece queen)
    {
        if (queen.rank != ChessPiece.Rank.QUEEN) throw new System.ArgumentException();
        List<string> possibleMoves = new List<string>();
        return possibleMoves;
    }

    List<string> CalculateKingMoves(ChessPiece king)
    {
        List<string> possibleMoves = new List<string>();
        return possibleMoves;
    }*/
}
