using UnityEngine;

public class RotatingCube : MonoBehaviour {

	void Update () {
		transform.Rotate(Vector3.up, 90.0f * Time.deltaTime);
	}
}
