using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    //Singleton
    public static WinManager instance;

    public int resourcesRequired;
    public int currentResourceCount;

    public string NextSceneName;

    private ResourceManagement resourceManager;

    public bool canGoOut;

    private void Start()
    {
        resourceManager = ResourceManagement.instance;

        #region Maintain a single instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }

    private void Update()
    {
        currentResourceCount = resourceManager.resourcePoints;

        if (currentResourceCount >= resourcesRequired)
        {
            canGoOut = true;
        }
        else
        {
            canGoOut = false;
        }
    }

    public void GetOutOfWater()
    {
        if (resourceManager.resourcePoints <= currentResourceCount)
        {
            TransitionAndLevelLoader.instance.PlayEndTransitionAndLoadLevel(NextSceneName);
        }
    }
}
