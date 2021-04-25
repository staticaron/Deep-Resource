using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private string levelToLoad;

    private void Start()
    {
        levelToLoad = "Level" + PlayerPrefs.GetInt("BestLevel").ToString();
        print(levelToLoad);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TransitionAndLevelLoader.instance.PlayEndTransitionAndLoadLevel(levelToLoad);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}
