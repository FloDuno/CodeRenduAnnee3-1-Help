﻿using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    public float perspectiveZoomSpeed = 0.5f; // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.5f; // The rate of change of the orthographic size in orthographic mode.
    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // If the _camera is orthographic...
            if (_camera.orthographic)
            {
                // ... change the orthographic size based on the change in distance between the touches.
                _camera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

                // Make sure the orthographic size never drops below zero.
                _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, 1f, 15f);
            }
            else
            {
                // Otherwise change the field of view based on the change in distance between the touches.
                _camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                // Clamp the field of view to make sure it's between 0 and 180.
                _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, 15f, 100f);
            }
        }
    }
}