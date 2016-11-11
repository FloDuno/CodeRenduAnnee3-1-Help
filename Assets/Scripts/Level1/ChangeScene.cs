using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    void OnTriggerEnter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(SceneManager.GetActiveScene().buildIndex + 1));
    }
}
