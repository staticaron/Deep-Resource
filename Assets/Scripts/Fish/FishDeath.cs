using UnityEngine;

public class FishDeath : MonoBehaviour
{
    public int sample;
    protected int samplesample;
    public delegate void FishDied(FishTypes types);
    public static event FishDied eFishDied;

    protected void FishDead(FishTypes fishType)
    {
        if (eFishDied != null) eFishDied(fishType);
        Debug.Log("Fish was dead");
    }

}

