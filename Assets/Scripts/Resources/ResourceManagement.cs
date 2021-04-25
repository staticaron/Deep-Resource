using UnityEngine;

public class ResourceManagement : MonoBehaviour
{

    //Singleton
    public static ResourceManagement instance;

    [SerializeField]
    private int resourcePoints;
    [SerializeField]
    private int oxygenPoints;
    [SerializeField]
    private int depthPoints;
    [SerializeField]
    private int naturePoints;

    private void Awake()
    {
        #region Maintain single entity
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        #endregion
    }

    private void Start()
    {
        FishDeath.eFishDied += updateResourcePoints;
        FishDeath.eFishDied += updateOxygenPoints;
    }

    private void OnDisable()
    {
        FishDeath.eFishDied -= updateResourcePoints;
        FishDeath.eFishDied -= updateOxygenPoints;
    }



    void updateResourcePoints(FishTypes fishType)
    {

    }

    void updateOxygenPoints(FishTypes fishType)
    {
        if (fishType == FishTypes.Normal)
        {
            this.oxygenPoints += 1;
        }
        else
        {
            this.oxygenPoints += 2;
        }
    }

    void updateNaturePoints(FishTypes fishType)
    {
        if (fishType == FishTypes.Normal)
        {
            this.naturePoints -= 1;
        }
        else
        {
            this.naturePoints -= 1;
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
