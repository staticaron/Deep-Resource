using UnityEngine;

public class FishDeath : MonoBehaviour
{
    public int sample;
    protected int samplesample;
    protected delegate void FishDied(FishTypes types);
    protected static event FishDied eFishDied;

    protected void FishDead(FishTypes fishType)
    {
        if (eFishDied != null) eFishDied(fishType);
    }

}

