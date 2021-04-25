using UnityEngine;

public class ResourceManagement : MonoBehaviour
{
    [SerializeField]
    private int resourcePoints;
    [SerializeField]
    private int oxygenPoints;
    [SerializeField]
    private int depthPoints;

    public int GetResources()
    {
        return resourcePoints;
    }

    public int GetOxygen()
    {
        return oxygenPoints;
    }

    public int GetDepth()
    {
        return depthPoints;
    }
}
