using UnityEngine;
using UnityEngine.SceneManagement;

//Go to next level
public class ChangeScene : MonoBehaviour
{
    //Used to know when we can to next level
    [SerializeField] private ArchOpening _archOpening;

    void OnTriggerEnter()
    {
        if (!_archOpening._archOpened) return;
        //Get to next scene in build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(SceneManager.GetActiveScene().buildIndex + 1));
    }
}
