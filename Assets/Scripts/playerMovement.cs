using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpSpeed;

    private float groundPressed;
    private float groundPressedTime = 0.2f;

    private float jumpPressed;
    private float jumpPressedTime = 0.2f;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float input;
    private float movement;

    public Animator anim;

    [HideInInspector]
    public bool canMove;

    public bool isJump;





    void Start(){
        canMove = true;
    }

    void Update()
    {
        if(!canMove) return;

        input = Input.GetAxisRaw("Horizontal");
        movement = input * speed;
        if(Mathf.Abs(input) > 0.01){
            anim.SetBool("isMoving" , true);
        }
        else{
            anim.SetBool("isMoving" , false);
        }

        if(isJumping){
            anim.SetBool("isJumping" , true);
        }
        else {
            anim.SetBool("isJumping" , false);
        }

        if(Input.GetKey(KeyCode.W)){
            jumpPressed = jumpPressedTime;
            if(isJump){
                FindObjectOfType<AudioManager>().Play("Jump");
                isJump = false;
            }
        }
    }

    void FixedUpdate(){
        move();
        jump();
    }

    void move(){
        rb.velocity = new Vector2(movement * Time.fixedDeltaTime , rb.velocity.y);

        if(isFacingRight && input == 1){
            Flip();
        }
        else if(!isFacingRight && input == -1){
            Flip();
        }
    }

    private bool isJumping = false;
    void jump(){

        isGrounded = Physics2D.OverlapCircle(groundCheck.position , checkRadius , whatIsGround);
        
        jumpPressed -= Time.deltaTime;
        groundPressed -= Time.deltaTime;

        if(isGrounded){
            groundPressed = groundPressedTime;
        }

        /*if(Input.GetKey(KeyCode.W)){
            jumpPressed = jumpPressedTime;
        }*/

        if(jumpPressed > 0 && groundPressed > 0){
            rb.velocity = new Vector2(rb.velocity.x , jumpSpeed * Time.fixedDeltaTime);
        }

        if(isGrounded){
            isJumping = false;
            isJump = true;
        }

        else{
            isJumping = true;
        }
    }

    private bool isFacingRight;
    void Flip(){
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
