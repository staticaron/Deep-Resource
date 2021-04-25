using UnityEngine;

public class ResourceManagement : MonoBehaviour
{

    //Singleton
    public static ResourceManagement instance;

    [SerializeField]
    public int resourcePoints;
    [SerializeField]
    public int oxygenPoints;

    public int OxygenPoints
    {
        get { return oxygenPoints; }
        set { oxygenPoints = value; if (oxygenPoints > 10) { oxygenPoints = 10; } }
    }

    [SerializeField]
    public int depthPoints;
    [SerializeField]
    public int naturePoints;
    [SerializeField]
    public int health;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    public int GetNature()
    {
        return naturePoints;
    }
}
