using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float maxFallSpeed;

    public Vector2 inputVector;
    private Vector2 movementVector;
    private Rigidbody2D rb;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        //Take input from the player
        inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        inputVector.Normalize();

        if (inputVector.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (inputVector.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Mathf.Abs(inputVector.y) > 0.1)
        {
            movementVector = new Vector2(inputVector.x * moveSpeed, inputVector.y * moveSpeed);
        }
        else
        {
            movementVector = new Vector2(inputVector.x * moveSpeed, Mathf.Clamp(rb.velocity.y, -maxFallSpeed, Mathf.Infinity));
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movementVector;
    }
}
