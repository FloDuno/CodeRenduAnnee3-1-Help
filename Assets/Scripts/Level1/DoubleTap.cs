using UnityEngine;

//Used to go forward
public class DoubleTap : MonoBehaviour
{
    public float distance;
    private Vector3 destination;

    void Update()
    {
        //If double touch, update where to go (aka forward)
        if (Input.GetTouch(0).tapCount == 2)
        {
            destination = transform.forward * distance;
        }
        else
        {
            destination = Vector3.zero;
        }
        transform.position += destination * Time.deltaTime;
    }
}