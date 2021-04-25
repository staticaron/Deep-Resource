using UnityEngine;
using System.Collections.Generic;

public class FishAttack : MonoBehaviour
{
    [SerializeField]
    private int attackValue;
    [SerializeField]
    private bool canAttack = true;
    [SerializeField]
    private float attackCooldown;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (canAttack == true)
            {
                //Amend Damage
                Health playerHealth = other.GetComponent<Health>();
                playerHealth.TakeDamage(attackValue);

                //Run Cooldown to prevent many attacks at once
                canAttack = false;
                StartCoroutine(RunCoolDown());
            }
        }
    }

    private IEnumerator<WaitForSeconds> RunCoolDown()
    {
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }

}
