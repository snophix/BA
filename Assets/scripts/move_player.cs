using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class move_player : MonoBehaviour
{
    PlayerControls controls;

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
    public Vector2 Movement;
    public Vector2 originalMovement;

    public static move_player instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance of move_player");
            return;
        }

        instance = this;

        controls = new PlayerControls();

        controls.GmaePlay.Jump.performed += ctx => JumpAction();
        controls.GmaePlay.Move.performed += ctx => originalMovement = ctx.ReadValue<Vector2>();
        controls.GmaePlay.Move.canceled += ctx => originalMovement = Vector2.zero;
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

        Movement = new Vector2(originalMovement.x * moveSpeed * Time.deltaTime, originalMovement.y * moveSpeed * Time.deltaTime);

        if(originalMovement != Vector2.zero)
        {
            target = transform.position + new Vector3(originalMovement.x, 0, originalMovement.y);
            transform.LookAt(target);
        }
    }

    void FixedUpdate()
    {
        MovePlayer(Movement);
    }

    public void JumpAction()
    {
        if(isGrounded)
        {
            isJumping = true;
        }else if(canDoubleJump)
        {
            isDoubleJumping = true;
            canDoubleJump = false;
        }
    }
    void MovePlayer(Vector2 traget2)
    {
        Vector3 targetVelocity = new Vector3(traget2.x, rb.velocity.y, traget2.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref Velocity, .04f);

        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }else if(isDoubleJumping)
        {
            rb.AddForce(new Vector2(0f, doubleJumpForce));
            isDoubleJumping = false;
        }
    }

    void OnEnable()
    {
        controls.GmaePlay.Enable();
    }
}
