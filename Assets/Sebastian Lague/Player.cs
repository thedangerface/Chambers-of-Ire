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

    public float wallSlideSpeedMax = 3;

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;

    PlayerAnimationManager playerAnimationManager;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Controller2D>();
        playerAnimationManager = GetComponent<PlayerAnimationManager>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity * timeToJumpApex);
        print("Gravity: " + gravity + " Jump Velocity: " + jumpVelocity);
    }

    // Update is called once per frame
    void Update()
    {

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }
        
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //jump controls

        if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
            //print("space pressed at " + Time.time);
        }

        // if you want to control the jump so that you start falling as soon as you let go
        // you will need to reset the player's velocity to zero

        if (Input.GetKeyUp(KeyCode.Space) && !controller.collisions.below && velocity.y > 0)
        {
            velocity.y = 0;
            // need a way to briefly and accurate boost downward speed
            // maybe log jump start time? calculate speed based off how much time you have to fall.
            // look at the calculations for jump height
            // don't forget to compensate for gravity's pull

            //print("space released at " + Time.time);
        }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            playerAnimationManager.stateInfo.attacking = true;
        }

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, 
            (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
