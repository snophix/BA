using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_player : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    public float jumpForce;
    public float doubleJumpForce;

    public float rotation;
    public float previousRotation;

    private bool isJumping;
    public bool isGrounded;
    private bool canDoubleJump;
    private bool isDoubleJumping;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    private Vector3 Velocity = Vector3.zero;
    public Vector3 previousTraget;
    public Vector3 target;
    public float horizontalMovement;
    public float verticalMovement;

    public static move_player instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance of move_player");
            return;
        }

        instance = this;
    }

    void Start()
    {
        //rb=this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(isGrounded)
        {
            canDoubleJump = true;
        }
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            target = transform.position + new Vector3(horizontalMovement, 0, verticalMovement);
            transform.LookAt(target);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }else if(Input.GetButtonDown("Jump") && canDoubleJump)
        {
            isDoubleJumping = true;
        }
    }

    void FixedUpdate()
    {
        MovePlayer(horizontalMovement, verticalMovement);
    }
    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector3(_horizontalMovement, rb.velocity.y, _verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref Velocity, .04f);

        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }else if(isDoubleJumping)
        {
            rb.AddForce(new Vector2(0f, doubleJumpForce));
            canDoubleJump = false;
            isDoubleJumping = false;
        }
    }
}
