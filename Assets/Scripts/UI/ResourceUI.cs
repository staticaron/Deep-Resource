using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text resourcesValue, oxygenValue, depthValue, natureValue;
    [SerializeField]
    private Slider healthUISlider;

    private void Start()
    {
        FishDeath.eFishDied += UpdateOxygenUI;
        FishDeath.eFishDied += UpdateNatureUI;
        Health.eDamageTaken += UpdateHealthUI;
    }

    private void OnDisable()
    {
        FishDeath.eFishDied -= UpdateOxygenUI;
        FishDeath.eFishDied -= UpdateNatureUI;
        Health.eDamageTaken -= UpdateHealthUI;
    }

    private void UpdateOxygenUI(FishTypes fishType)
    {
        //Update the ui to display the correct numbers
        oxygenValue.text = ResourceManagement.instance.GetOxygen().ToString();
    }

    private void UpdateNatureUI(FishTypes fishType)
    {
        //Update the ui to display the correct numbers
        oxygenValue.text = ResourceManagement.instance.GetNature().ToString();
    }

    private void UpdateResourcesUI()
    {

    }

    private void UpdateHealthUI(int healthLeft)
    {
        //Set the health ui slider value to the players current health
        healthUISlider.value = healthLeft;
    }

}
