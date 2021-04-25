using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Singleton
    public static Health instance;

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

    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

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

    //Making public because of death with oxygen
    public void Dead()
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
