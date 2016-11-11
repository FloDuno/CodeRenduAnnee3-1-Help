using System;
using UnityEngine;

//Useful to know what to check
public enum Channels
{
    R,
    G,
    B
}

public class ColorCheck : MonoBehaviour
{
    //Channel to display for this cube
    public Channels channel;
    //Count the right answers
    public static bool[] rightColor;
    //Set the color to find
    public Color colorToDivide;

    void Start()
    {
        //Divide every channel of the color and assign it to materials
        switch (channel)
        {
            case Channels.R:
                GetComponent<MeshRenderer>().material.color = new Color(colorToDivide.r,0,0);
                break;
            case Channels.G:
                GetComponent<MeshRenderer>().material.color = new Color(0,colorToDivide.r,0);
                break;
            case Channels.B:
                GetComponent<MeshRenderer>().material.color = new Color(0,0,colorToDivide.r);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        //Make sure we have the right number of cubes to check
        rightColor = new bool[3];
    }

    void OnTriggerEnter(Collider _collider)
    {
        //When the player drop cube on it, we check if the color's all right
        //If so we destroy the player's cube and get a point
        switch (channel)
        {
            case Channels.R:
                if (Mathf.Abs(_collider.GetComponent<MeshRenderer>().material.color.r - GetComponent<MeshRenderer>().material.color.r) < 0.15f)
                {
                    AddRightColor();
                    Destroy(_collider.gameObject);
                }

                break;
            case Channels.G:
                if (Mathf.Abs(_collider.GetComponent<MeshRenderer>().material.color.g - GetComponent<MeshRenderer>().material.color.g) < 0.15f)
                {
                    AddRightColor();
                    Destroy(_collider.gameObject);
                }
                break;
            case Channels.B:
                if (Mathf.Abs(_collider.GetComponent<MeshRenderer>().material.color.b - GetComponent<MeshRenderer>().material.color.b) < 0.15f)
                {
                    AddRightColor();
                    Destroy(_collider.gameObject);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    //Get a point by adding filling an array of booleans with one more "true"
    void AddRightColor()
    {
        for (int _i = 0; _i < rightColor.Length; _i++)
        {
            if (rightColor[_i]) continue;
            rightColor[_i] = true;
            if (_i == rightColor.Length - 1)
                print("victoire");
            return;
        }
    }
}