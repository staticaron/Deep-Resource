using UnityEngine;
using System.Collections.Generic;

public class OxygenManager : MonoBehaviour
{

    private WaitForSeconds wfs;
    [SerializeField]
    private float timeToReduceOxygen;

    private ResourceManagement resourceManager;
    private ResourceUI resourceUI;

    private void Start()
    {
        wfs = new WaitForSeconds(timeToReduceOxygen);

        resourceManager = ResourceManagement.instance;
        resourceUI = ResourceUI.instance;

        StartCoroutine(reduceOxygen());
    }

    private IEnumerator<WaitForSeconds> reduceOxygen()
    {
        while (true)
        {
            yield return wfs;

            resourceManager.oxygenPoints -= 1;
            resourceUI.UpdateUI();

            if (resourceManager.oxygenPoints <= 0)
            {
                Health.instance.Dead();
            }
        }
    }
}
