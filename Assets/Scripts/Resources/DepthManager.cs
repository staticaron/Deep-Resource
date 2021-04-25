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
        int depth = (int)(pos.y - surfaceAltitude);
        resourceUI.UpdateDepth(depth);
    }
}
