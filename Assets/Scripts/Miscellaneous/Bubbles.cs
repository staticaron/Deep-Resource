using UnityEngine;

public class Bubbles : MonoBehaviour
{
    [SerializeField]
    private float timeToDisable;
    [SerializeField]
    private GameObject bubbleObject;

    private void Update()
    {
        if (bubbleObject.activeInHierarchy)
        {
            Invoke("Disable", timeToDisable);
        }
    }

    void Disable()
    {
        bubbleObject.SetActive(false);
    }
}
