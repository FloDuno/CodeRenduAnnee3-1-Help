using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    [SerializeField] private ArchOpening _archOpening;

    void OnTriggerEnter()
    {
        if (!_archOpening._archOpened) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(SceneManager.GetActiveScene().buildIndex + 1));
    }
}
