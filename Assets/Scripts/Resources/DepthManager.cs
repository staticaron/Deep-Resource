using UnityEngine;

public class DepthManager : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float surfaceAltitude;

    //For Caching
    private ResourceUI resourceUI;

    private void Start()
    {
        resourceUI = ResourceUI.instance;
    }

    private void Update()
    {
        Vector2 pos = player.position;
        int depth = Mathf.Abs((int)(pos.y - surfaceAltitude));
        //Updating resource manager so that every info can be found at one place
        ResourceManagement.instance.depthPoints = depth;

        //Update UI
        resourceUI.UpdateDepth(depth);
    }
}
