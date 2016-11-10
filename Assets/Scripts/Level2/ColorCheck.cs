using System;
using UnityEngine;

public enum Channels
{
    R,
    G,
    B
}

public class ColorCheck : MonoBehaviour
{
    public Channels channel;
    public static bool[] rightColor;
    public Color colorToDivide;

    void Start()
    {
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
        rightColor = new bool[3];
    }

    void OnTriggerEnter(Collider _collider)
    {
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