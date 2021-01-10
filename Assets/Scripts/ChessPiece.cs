using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

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

    public bool held;
    public Color color;
    public Rank rank;
    public GameObject piece;
    public string position;
    public Vector2 coordinates; // for chess game theory... eventually...

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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something touched me!");
        // If touching tile
        if (other.gameObject.CompareTag("Tile"))
        {
            position = other.gameObject.name;
            Debug.Log(this.gameObject.name + " : " + other.gameObject.name);
        }
        else if (other.gameObject.CompareTag("Hand"))
        {
            Debug.Log("Hand is touching!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Colliding with something!");
        if (other.gameObject.CompareTag("Hand"))
        {
            InputDevice leftHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
            InputDevice rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

            float triggerValue, gripValue;

            // See if either hand is holding onto the piece with trigger or grip buttons
            bool leftHeld = leftHandDevice.TryGetFeatureValue(CommonUsages.trigger, out triggerValue)
                            || leftHandDevice.TryGetFeatureValue(CommonUsages.grip, out gripValue);
            bool rightHeld = rightHandDevice.TryGetFeatureValue(CommonUsages.trigger, out triggerValue)
                            || rightHandDevice.TryGetFeatureValue(CommonUsages.grip, out gripValue);

            if (leftHeld && rightHeld)
            {
                Debug.Log("Holding piece!");
                held = true;
            }
            else held = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            held = false;
        }
    }
}
