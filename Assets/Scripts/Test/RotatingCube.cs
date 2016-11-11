using UnityEngine;

//I won't explain https://media.giphy.com/media/3o8doRfRrlP6MTJTgY/giphy.gif
public class RotatingCube : MonoBehaviour {

	void Update () {
		transform.Rotate(Vector3.up, 90.0f * Time.deltaTime);
	}
}
