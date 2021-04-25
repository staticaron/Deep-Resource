using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float timeToChangeDirection;
    [SerializeField]
    private float minAngle, maxAngle;
    [SerializeField]
    private float minAltitude, maxAltitude;
    [SerializeField]
    private float minHorizontal, maxHorizontal;

    [SerializeField]
    private RectTransform fishContainer;
    private Vector3[] corners;

    private bool upMovementAllowed;
    private bool downMovementAllowed;
    [SerializeField]
    private bool rightMovementAllowed;
    [SerializeField]
    private bool leftMovementAllowed;

    private WaitForSeconds waiterChangeDirection;
    private Vector2 currentDirection = Vector2.right;

    private void Start()
    {
        StartCoroutine(ChangeDirection(this.timeToChangeDirection));

        corners = new Vector3[4];

        fishContainer.GetWorldCorners(corners);
        minAltitude = corners[0].y;
        maxAltitude = corners[1].y;
        minHorizontal = corners[0].x;
        maxHorizontal = corners[2].x;

        print(minAltitude.ToString() + maxAltitude.ToString() + minHorizontal.ToString() + maxHorizontal.ToString());
    }

    private void Update()
    {
        Vector2 direction = (Vector2)this.transform.position + currentDirection * moveSpeed * Time.deltaTime;
        transform.position = direction;

        //Maintain the valid height
        if (transform.position.y > maxAltitude)
        {
            upMovementAllowed = false;
            downMovementAllowed = true;
            ChangeDir();
        }
        else if (transform.position.y < minAltitude)
        {
            upMovementAllowed = true;
            downMovementAllowed = false;
            ChangeDir();
        }
        else
        {
            upMovementAllowed = true;
            downMovementAllowed = true;
        }

        //Maintain the valid distance
        if (transform.position.x > maxHorizontal)
        {
            leftMovementAllowed = true;
            rightMovementAllowed = false;
            ChangeDir();
        }
        else if (transform.position.x < minHorizontal)
        {
            leftMovementAllowed = false;
            rightMovementAllowed = true;
            ChangeDir();
        }
        else
        {
            leftMovementAllowed = true;
            rightMovementAllowed = true;
        }
    }

    private IEnumerator<WaitForSeconds> ChangeDirection(float timeToChangeDirection)
    {
        while (true)
        {

            yield return new WaitForSeconds(timeToChangeDirection);

            ChangeDir();
        }

    }

    void ChangeDir()
    {
        //Set a random direction

        float randomAngleInRad;

        int shouldMoveLeft = Random.Range(0, 2);

        if (shouldMoveLeft == 0)
        {

            //Move right only if allowed to move right else move left
            if (rightMovementAllowed == true)
            {
                //Move right
                if (upMovementAllowed == false)
                {

                    randomAngleInRad = UnityEngine.Random.Range((int)minAngle * Mathf.Deg2Rad, 0);
                }
                else if (downMovementAllowed == false)
                {

                    randomAngleInRad = UnityEngine.Random.Range(0, (int)maxAngle * Mathf.Deg2Rad);
                }
                else
                {

                    randomAngleInRad = UnityEngine.Random.Range((int)minAngle * Mathf.Deg2Rad, (int)maxAngle * Mathf.Deg2Rad);
                }

                //Set the correct rotation
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                //Move left since the previous one was not allowed
                if (upMovementAllowed == false)
                {

                    randomAngleInRad = UnityEngine.Random.Range(UnityEngine.Random.Range(-180, -180 - minAngle) * Mathf.Deg2Rad, 0);
                }
                else if (downMovementAllowed == false)
                {

                    randomAngleInRad = UnityEngine.Random.Range(0, UnityEngine.Random.Range(180 - maxAngle, 180) * Mathf.Deg2Rad);
                }
                else
                {

                    randomAngleInRad = (180 - (UnityEngine.Random.Range(180 - maxAngle, 180) + UnityEngine.Random.Range(-180, -180 - minAngle)) * 0.5f) * Mathf.Deg2Rad;
                }

                //Set the correct rotation
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {

            //Move left only if allowed to move left else move right
            if (leftMovementAllowed == true)
            {
                if (upMovementAllowed == false)
                {

                    randomAngleInRad = UnityEngine.Random.Range(UnityEngine.Random.Range(-180, -180 - minAngle) * Mathf.Deg2Rad, 0);
                }
                else if (downMovementAllowed == false)
                {

                    randomAngleInRad = UnityEngine.Random.Range(0, UnityEngine.Random.Range(180 - maxAngle, 180) * Mathf.Deg2Rad);
                }
                else
                {

                    randomAngleInRad = (180 - (UnityEngine.Random.Range(180 - maxAngle, 180) + UnityEngine.Random.Range(-180, -180 - minAngle)) * 0.5f) * Mathf.Deg2Rad;
                }

                //Set the correct rotation
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                //Move right since the previous one was not allowed 
                if (upMovementAllowed == false)
                {

                    randomAngleInRad = UnityEngine.Random.Range((int)minAngle * Mathf.Deg2Rad, 0);
                }
                else if (downMovementAllowed == false)
                {

                    randomAngleInRad = UnityEngine.Random.Range(0, (int)maxAngle * Mathf.Deg2Rad);
                }
                else
                {

                    randomAngleInRad = UnityEngine.Random.Range((int)minAngle * Mathf.Deg2Rad, (int)maxAngle * Mathf.Deg2Rad);
                }

                //Set the correct rotation
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        Debug.Log(shouldMoveLeft);
        Debug.Log(randomAngleInRad * Mathf.Rad2Deg);

        currentDirection = new Vector2(Mathf.Cos(randomAngleInRad), Mathf.Sin(randomAngleInRad));
    }
}
