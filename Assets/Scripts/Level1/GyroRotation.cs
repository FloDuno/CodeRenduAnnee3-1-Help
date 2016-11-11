using UnityEngine;
using System.Collections;

//Gyroscope
public class GyroRotation : MonoBehaviour
{
    private Quaternion _origin = Quaternion.identity;

    //Enable gyroscope and get neutral point
    void Start()
    {
        Input.gyro.enabled = true;
        _origin = Input.gyro.attitude;
    }

    void Update()
    {
        //Reset _origin on touch or not yet set _origin
        if (Input.touchCount > 0 || _origin == Quaternion.identity)
            StartCoroutine(Calibrate());
        //Convert quaternion to Euler since one axis is in the wrong way
        Quaternion _temp = Quaternion.Inverse(Quaternion.Inverse(_origin) *Input.gyro.attitude);
        Vector3 _tempVector3 = _temp.eulerAngles;
        _tempVector3 = new Vector3(_tempVector3.x, _tempVector3.y, -_tempVector3.z);
        transform.localRotation = Quaternion.Lerp(transform.localRotation,Quaternion.Euler(_tempVector3), 0.8f);
    }

    IEnumerator Calibrate()
    {
        //If we let our finger more than 1.5seconds on screen, reser gyroscope
        float _timer = 0;
        while (Input.touchCount > 0)
        {
            _timer += Time.deltaTime;
            yield return null;
        }
        if (_timer > 1.5f)
            _origin = Input.gyro.attitude;
    }

    void OnGUI()
    {
        GUILayout.Label(_origin.eulerAngles + " <- _origin");
        GUILayout.Label(Input.gyro.attitude.eulerAngles + " <- gyro");
        GUILayout.Label(Quaternion.Inverse(Input.gyro.attitude).eulerAngles + " <- inv gyro");
        GUILayout.Label(transform.localRotation.eulerAngles + " <- localRotation");
    }
}