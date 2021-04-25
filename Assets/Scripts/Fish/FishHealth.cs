using UnityEngine;

public class FishHealth : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private FishTypes fishType;

    private int Health
    {
        get { return this.health; }
        set { this.health = value; }
    }

    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;

        if (Health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        ResourceManagement resourceManager = ResourceManagement.instance;

        //Nature Reduction
        resourceManager.naturePoints -= 1;

        //Give oxygen to the player
        if (fishType == FishTypes.Normal)
        {
            resourceManager.OxygenPoints += 1;
        }
        else
        {
            resourceManager.OxygenPoints += 2;
        }

        ResourceUI.instance.UpdateUI();

        StartCoroutine(PlayerAttack.instance.RemoveEntryFromAttackFishCollection(this.gameObject));

        this.gameObject.SetActive(false);

        //Spawn death particles
    }
}
