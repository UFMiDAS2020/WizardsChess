using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public enum Color
    {
        WHITE,
        BLACK
    }

    public enum Rank
    {
        PAWN,
        BISHOP,
        KNIGHT,
        ROOK,
        QUEEN,
        KING
    }

    public Color color;
    public Rank rank;
    public GameObject piece;
    public string position;
    public Vector2 coordinates;

    private int value;

    private void Start()
    {
        piece = gameObject;
        switch(rank)
        {
            case Rank.PAWN:
                value = 1;
                break;
            case Rank.BISHOP:
                value = 3;
                break;
            case Rank.KNIGHT:
                value = 3;
                break;
            case Rank.ROOK:
                value = 5;
                break;
            case Rank.QUEEN:
                value = 9;
                break;
            default:
                value = -1; // null (King) or error
                break;
        }
    }
}
