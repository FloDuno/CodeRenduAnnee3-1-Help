using System;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector3 _originPos;
    public Channels channel;
    public Material baseMaterial;

    void Start()
    {
        _originPos = transform.position;
    }

    void LateUpdate()
    {
        //Change the color of the cube based on the chosen channel and the average color of webcam texture
        Color _actualColor = baseMaterial.color;
        switch (channel)
        {
            case Channels.R:
                GetComponent<MeshRenderer>().material.color = new Color(_actualColor.r, 0, 0);
                break;
            case Channels.G:
                GetComponent<MeshRenderer>().material.color = new Color(0, _actualColor.g, 0);
                break;
            case Channels.B:
                GetComponent<MeshRenderer>().material.color = new Color(0, 0, _actualColor.b);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    //When we drag and drop, follow the finger along the y axis
    void OnMouseDrag()
    {
        Vector3 _screenPosition = new Vector3(0, Input.mousePosition.y, gameObject.transform.position.z - Camera.main.transform.position.z);
        Vector3 _point = Camera.main.ScreenToWorldPoint(_screenPosition);
        gameObject.transform.position = new Vector3(transform.position.x, _point.y, _point.z);
    }

    //When we stop the drag, destroy the object
    void OnMouseUp()
    {
        transform.position = _originPos;
    }
}