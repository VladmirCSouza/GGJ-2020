using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Vector2 movement = Vector2.zero;
    [SerializeField] private float speed = 25.0f;
    [SerializeField] private float jumpForce = 200.0f;

    private new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(IsGrounded() && IsJumpKeyPressed() && !StageManager.Instance.IsGameOver()) {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (!StageManager.Instance.IsGameOver())
        {
            Move();
        }
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
        return rigidbody2D.velocity.y == 0;
    }
}
