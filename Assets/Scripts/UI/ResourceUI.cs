using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    //Singletons
    public static ResourceUI instance;

    [SerializeField]
    private TMP_Text resourcesValue, oxygenValue, depthValue, natureValue;
    [SerializeField]
    private Slider healthUISlider;

    private void Awake()
    {
        #region  Maintain single entity
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

    private void UpdateOxygenUI(int points)
    {
        oxygenValue.text = points.ToString();
    }

    private void UpdateNatureUI(int points)
    {
        natureValue.text = points.ToString();
    }

    private void UpdateResourcesUI(int points)
    {
        resourcesValue.text = points.ToString();
    }

    private void UpdateHealthUI(int healthLeft)
    {
        //Set the health ui slider value to the players current health
        healthUISlider.value = healthLeft;
    }

    private void UpdateDeathUI(int depthValue)
    {
        this.depthValue.text = depthValue.ToString();
    }

    public void UpdateUI()
    {
        ResourceManagement resourceManager = ResourceManagement.instance;

        UpdateOxygenUI(resourceManager.oxygenPoints);
        UpdateHealthUI(resourceManager.health);
        UpdateNatureUI(resourceManager.naturePoints);
        UpdateResourcesUI(resourceManager.resourcePoints);
    }

    //This exist to prevent the all the ui elements to update every single frame
    public void UpdateDepth(int depthValue)
    {
        UpdateDeathUI(depthValue);
    }

}
