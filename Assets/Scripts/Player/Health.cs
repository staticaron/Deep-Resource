using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int currentHealth;

    public int health
    {
        get { return currentHealth; }
        private set { currentHealth = value; }
    }

    [SerializeField]
    private Animator hurtAnimation;

    //Damage Events
    public delegate void DamageTaken(int currentHealth);
    public static event DamageTaken eDamageTaken;

    public void TakeDamage(int healthDamage)
    {
        //Reduce Health
        health -= healthDamage;

        if (health <= 0)
        {
            Dead();
        }

        //Spawn Death Particles

        ShowHurtBlinking();

        if (eDamageTaken != null) eDamageTaken(health);

    }

    private void Dead()
    {
        //Do Something

        //Reload level
        StartCoroutine(ReloadLevel());
    }

    private IEnumerator<WaitForSeconds> ReloadLevel()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Worst function name ever :|
    private void ShowHurtBlinking()
    {
        hurtAnimation.SetTrigger("PlayerHurt");
    }
}
