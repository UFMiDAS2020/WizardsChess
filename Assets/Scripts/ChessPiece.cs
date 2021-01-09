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
        PAWN,   // 1 pt.
        BISHOP, // 3 pts.
        KNIGHT, // 3 pts.
        ROOK,   // 5 pts.
        QUEEN,  // 9 pts.
        KING    // Infinity pts. (or null pts.)
    }

    public Color color;
    public Rank rank;
    public Vector3 coordinates;

    private int value;
    private string position;
    private GameObject piece;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate the piece's value
        value = rank switch
        {
            Rank.PAWN => 1,
            Rank.BISHOP => 3,
            Rank.KNIGHT => 3,
            Rank.ROOK => 5,
            Rank.QUEEN => 9,
            _ => -1, // null (King) or error
        };
    }

    public void UpdateCoordinates(Vector2 newCoordinates)
    {
        coordinates = newCoordinates;
    }

    public Vector2 ConvertPositionToCoordinates(string position)
    {
        float x = position.Substring(0, 1) switch
        {
            "A" => 0,
            "B" => 1,
            "C" => 2,
            "D" => 3,
            "E" => 4,
            "F" => 5,
            "G" => 6,
            "H" => 7,
            _ => throw new System.NotImplementedException()
        };
        float y = int.Parse(position.Substring(1, 1)) - 1;

        return new Vector2(x, y);
    }

    public string ConvertCoordinatesToPosition(Vector2 coordinates)
    {
        string letter = coordinates.x switch
        {
            0 => "A",
            1 => "B",
            2 => "C",
            3 => "D",
            4 => "E",
            5 => "F",
            6 => "G",
            7 => "H",
            _ => throw new System.NotImplementedException()
        };
        string number = coordinates.y.ToString();

        return letter + number;
    }
}
