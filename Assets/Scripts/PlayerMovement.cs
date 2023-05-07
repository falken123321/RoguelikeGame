using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 movement;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        moveSpeed = (float)this.gameObject.GetComponent<CharacterAttributes>().toPlayerData().movement_Speed;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 velocity = movement.normalized * moveSpeed;
        rb.velocity = velocity;
        
        animator.SetFloat("X",movement.x);
        animator.SetFloat("Y",movement.y);
    }
}