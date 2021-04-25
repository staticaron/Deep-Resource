using UnityEngine;

public class FishHealth : FishDeath
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
        base.FishDead(fishType);

        //Give negative rating to the player if normal fish
        //Give oxygen to the player

        //Update UI

        gameObject.SetActive(false);
        //Spawn death particles
    }
}
