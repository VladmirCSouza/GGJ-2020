using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Vector2 movement = Vector2.zero;
    [SerializeField] private float speed = 25.0f;
    [SerializeField] private float jumpForce = 200.0f;
    [SerializeField] private LayerMask raycastLayerMask;

    private Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(IsGrounded() && IsJumpKeyPressed()) {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        movement = new Vector2(Input.GetAxis("Horizontal") * speed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = movement;
    }

    private void Jump()
    {
        rigidbody2D.AddForce(new Vector2(0, jumpForce));
    }

    private bool IsJumpKeyPressed()
    {
        return Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position + (Vector3.down * 1.0f), Vector3.down, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3.down * 1.0f), Vector3.down, 0.5f, raycastLayerMask);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
}
