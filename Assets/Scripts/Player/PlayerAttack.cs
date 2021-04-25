using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Singletons
    //Just singletonning every object due to lack of time :{
    public static PlayerAttack instance;

    [SerializeField]
    private int damageDone;
    [SerializeField]
    private KeyCode AttackButton;

    [SerializeField]
    private List<GameObject> fishesInAttackArea;

    [SerializeField]
    private List<GameObject> resourcesInAttackArea;

    private bool changeAllowedInFishAttackArea;

    private void Start()
    {
        #region Maintain single entity
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
        #endregion
    }

    private void Update()
    {

        changeAllowedInFishAttackArea = true;

        if (Input.GetKeyDown(AttackButton))
        {
            //Stop taking new fishes into the fish attack area to prevent the change in collection during iteration
            changeAllowedInFishAttackArea = false;

            try
            {
                foreach (GameObject g in fishesInAttackArea)
                {
                    g.GetComponent<FishHealth>().TakeDamage(damageAmount: this.damageDone);
                }

                foreach (GameObject g in resourcesInAttackArea)
                {
                    Destroy(g);
                    resourcesInAttackArea.Remove(g);
                    ResourceManagement.instance.resourcePoints += 1;
                    ResourceUI.instance.UpdateUI();
                }
            }
            catch
            {

            }

            changeAllowedInFishAttackArea = true;

            BGM.instance.PlayHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fish") && changeAllowedInFishAttackArea == true)
        {
            //Add the fish to the attackable fish collection
            fishesInAttackArea.Add(other.gameObject);
        }

        if (other.CompareTag("Resource"))
        {
            resourcesInAttackArea.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Fish") && changeAllowedInFishAttackArea == true)
        {
            //Remove the fish from the attackable fish collection
            fishesInAttackArea.Remove(other.gameObject);
        }


        if (other.CompareTag("Resource"))
        {
            resourcesInAttackArea.Remove(other.gameObject);
        }
    }

    public IEnumerator<WaitUntil> RemoveEntryFromAttackFishCollection(GameObject g)
    {
        fishesInAttackArea.Remove(g);
        yield return new WaitUntil(() => changeAllowedInFishAttackArea == false);
    }
}
