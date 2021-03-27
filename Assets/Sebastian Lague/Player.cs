using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour
{

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    // Wall Jump
    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;
    public float wallSlideSpeedMax = 3;
    public float wallStickTime = 1f;
    float timeToWallUnstick; 

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;

    PlayerAnimationManager playerAnimationManager;

    void Start()
    {
        controller = GetComponent<Controller2D>();

        playerAnimationManager = GetComponent<PlayerAnimationManager>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity * timeToJumpApex);
        print("Gravity: " + gravity + " Jump Velocity: " + jumpVelocity);
    }

    void Update()
    {
        // MOVE INPUT
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        int wallDirectionX = (controller.collisions.left) ? -1 : 1;

        // VELOCITY CALC
        float targetVelocityX = input.x * moveSpeed;

        // SMOOTHING
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, 
            (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);

        // WALL JUMP/SLIDE CALC
        bool wallSliding = false;
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0) 
        {
            wallSliding = true;

            if (velocity.y < -wallSlideSpeedMax) 
                velocity.y = -wallSlideSpeedMax;

            if (timeToWallUnstick > 0) 
            {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if (input.x != wallDirectionX && input.x != 0)
                    timeToWallUnstick -= Time.deltaTime;
                else 
                    timeToWallUnstick = wallStickTime;
            }
            else 
                timeToWallUnstick = wallStickTime;
        }
        else 
            timeToWallUnstick = wallStickTime;

        if (controller.collisions.above || controller.collisions.below)
            velocity.y = 0;
        
        // JUMP INPUT
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (wallSliding) 
            {
                if (wallDirectionX == input.x) 
                {
                    velocity.x = -wallDirectionX * wallJumpClimb.x;
                    velocity.y = wallJumpClimb.y;
                }
                else if (input.x == 0)
                {
                    velocity.x = -wallDirectionX * wallJumpOff.x;
                    velocity.y = wallJumpOff.y;
                }
                else 
                {
                    velocity.x = -wallDirectionX * wallLeap.x;
                    velocity.y = wallLeap.y;
                }
            }

            if (controller.collisions.below) 
                velocity.y = jumpVelocity;
        }

        // ATTACK INPUT
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            playerAnimationManager.stateInfo.attacking = true;
        }

        // GRAVITY
        velocity.y += gravity * Time.deltaTime;

        // MOVE ENGINE
        controller.Move(velocity * Time.deltaTime);
    }
}
