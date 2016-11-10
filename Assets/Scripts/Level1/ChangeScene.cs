using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    void OnTriggerEnter()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
    }
}
