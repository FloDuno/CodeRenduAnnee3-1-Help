using UnityEngine;
using System.Collections;

public class GyroRotation : MonoBehaviour
{
    Quaternion origin = Quaternion.identity;

    void Start()
    {
        Input.gyro.enabled = true;
        origin = Input.gyro.attitude;
    }

    void Update()
    {
        // reset origin on touch or not yet set origin
        if (Input.touchCount > 0 || origin == Quaternion.identity)
            StartCoroutine(Calibrate());
        Quaternion _temp = Quaternion.Inverse(Quaternion.Inverse(origin) *Input.gyro.attitude);
        Vector3 _tempVector3 = _temp.eulerAngles;
        _tempVector3 = new Vector3(_tempVector3.x, _tempVector3.y, -_tempVector3.z);
        transform.localRotation = Quaternion.Lerp(transform.localRotation,Quaternion.Euler(_tempVector3), 0.8f);
    }

    IEnumerator Calibrate()
    {
        float _timer = 0;
        while (Input.touchCount > 0)
        {
            _timer += Time.deltaTime;
            yield return null;
        }
        if (_timer > 1.5f)
            origin = Input.gyro.attitude;
    }

    void OnGUI()
    {
        GUILayout.Label(origin.eulerAngles + " <- origin");
        GUILayout.Label(Input.gyro.attitude.eulerAngles + " <- gyro");
        GUILayout.Label(Quaternion.Inverse(Input.gyro.attitude).eulerAngles + " <- inv gyro");
        GUILayout.Label(transform.localRotation.eulerAngles + " <- localRotation");
    }
}