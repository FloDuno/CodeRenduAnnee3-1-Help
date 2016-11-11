using System.Collections;
using UnityEngine;

public class DisappearText : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(Disappear());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Disappear()
    {
        float _timer = 0;
        while (_timer < 5)
        {
            _timer += Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
