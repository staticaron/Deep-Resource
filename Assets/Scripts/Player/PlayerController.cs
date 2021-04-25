using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    //Singleton
    public static PlayerController instance;

    [SerializeField]
    public bool controllsEnabled;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float maxFallSpeed;
    [SerializeField]
    private KeyCode interactKey;

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
        //Maintain Single entity
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //Init
        inAir = false;
        controllsEnabled = true;
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

        if (controllsEnabled)
        {
            //Take input from the player
            inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            inputVector.Normalize();
        }

        //Rotate to face the direction of movement
        if (inputVector.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (inputVector.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        //Determine the move speed based on the vertical input
        if (Mathf.Abs(inputVector.y) > 0.1)
        {
            movementVector = new Vector2(inputVector.x * moveSpeed, inputVector.y * moveSpeed);
        }
        else
        {
            movementVector = new Vector2(inputVector.x * moveSpeed, Mathf.Clamp(rb.velocity.y, -maxFallSpeed, Mathf.Infinity));
        }

        //Check of out of water interactions
        if (Input.GetKeyDown(interactKey))
        {
            if (WinManager.instance.canGoOut == true)
            {
                WinManager.instance.GetOutOfWater();
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movementVector;
    }

    public void StopControl()
    {
        controllsEnabled = false;
        inputVector = Vector2.zero;
    }
}
