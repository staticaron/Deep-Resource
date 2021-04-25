using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator playerAnimator;
    private PlayerController playerController;
    [SerializeField]
    private GameObject bubbleSystem;
    [SerializeField]
    private float timeToBubble;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();

        StartCoroutine(Bubbles(timeToBubble));
    }

    private void Update()
    {
        if (playerController.inputVector.x != 0)
        {
            playerAnimator.SetInteger("HorizontalInput", 1);
        }
        else
        {
            playerAnimator.SetInteger("HorizontalInput", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("PlayerAttack");
        }
    }

    private IEnumerator<WaitForSeconds> Bubbles(float timeToSpawn)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToSpawn);

            //Only bubble if in water
            if (ResourceManagement.instance.depthPoints > 3)
            {
                bubbleSystem.SetActive(true);
            }
        }

    }

}
