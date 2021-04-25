using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private int damageDone;
    [SerializeField]
    private KeyCode AttackButton;

    [SerializeField]
    private List<GameObject> fishesInAttackArea;

    private bool changeAllowedInFishAttackArea;

    private void Update()
    {
        if (Input.GetKeyDown(AttackButton))
        {
            //Stop taking new fishes into the fish attack area to prevent the change in collection during iteration
            changeAllowedInFishAttackArea = false;

            foreach (GameObject g in fishesInAttackArea)
            {
                g.GetComponent<FishHealth>().TakeDamage(damageAmount: this.damageDone);
            }

            changeAllowedInFishAttackArea = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fish") && changeAllowedInFishAttackArea == true)
        {
            //Add the fish to the attackable fish collection
            fishesInAttackArea.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Fish") && changeAllowedInFishAttackArea == true)
        {
            //Remove the fish from the attackable fish collection
            fishesInAttackArea.Remove(other.gameObject);
        }
    }
}
