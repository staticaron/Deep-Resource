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

    [SerializeField]
    private Transform head;
    private bool wasInAir;
    public bool inAir;
    [SerializeField]
    private LayerMask airMask;

    private ResourceManagement resourceManager;

    private void Start()
    {
        inAir = false;
        rb = GetComponent<Rigidbody2D>();
        resourceManager = ResourceManagement.instance;
    }

    private void Update()
    {
        //Check for the current biome
        inAir = Physics2D.OverlapCircle(head.position, 0.1f, airMask);

        if (inAir == true)
        {
            resourceManager.oxygenPoints = 10;
        }

        if (wasInAir == false && inAir == true)
        {
            ResourceUI.instance.UpdateUI();
        }

        wasInAir = inAir;

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
