using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionAndLevelLoader : MonoBehaviour
{
    public static TransitionAndLevelLoader instance;

    private Animator thisAnim;
    private string levelToLoad;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //References
        thisAnim = GetComponent<Animator>();
    }

    public void PlayEndTransitionAndLoadLevel(string LevelName)
    {
        thisAnim.SetTrigger("TransitionOut");
        levelToLoad = LevelName;
    }

    public void LoadLevel()
    {
        Debug.Log(levelToLoad);
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
    }
}
