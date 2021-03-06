using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
  // MoveSpeed
  float baseMoveSpeed;
  float runSpeedIncrease = 1.75f;
  public float moveSpeed = 4f;

  private int knockbackForce = 20;

  // Jump
  public float maxJumpHeight = 3.25f;
  public float minJumpHeight = 0.5f;
  public float timeToJumpApex = .4f;
  float accelerationTimeAirborne = .2f;
  float accelerationTimeGrounded = .1f;
  float maxJumpVelocity;
  float minJumpVelocity;
  float jumpVelocity;
  int jumps = 0;
  int maxJumps = 2;

  // Attack
  public GameObject attackHitBox;

  // Wall Jump
  // public Vector2 wallJumpClimb;
  // public Vector2 wallJumpOff;
  // public Vector2 wallLeap;
  // public float wallSlideSpeedMax = 3;
  // public float wallStickTime = 0.25f;
  // float timeToWallUnstick;
  // bool wallSliding;
  // int wallDirectionX;

  float gravity;

  Vector3 velocity;
  float velocityXSmoothing;
  Vector2 directionalInput;

  [Header("Abilities")]
  public bool canMove = true;
  public bool canJump = true;
  // public bool canWallJump = false;
  public bool canDoubleJump = true;
  public bool canAttack = true;

  Controller2D controller;
  PlayerAnimationManager playerAnimationManager;

  private PlayerData playerData;
  public PlayerDisplay playerDisplay;

  private bool reviving = false;

  void Start()
  {
    controller = GetComponent<Controller2D>();
    playerAnimationManager = GetComponent<PlayerAnimationManager>();
    playerData = GetComponent<PlayerData>();

    baseMoveSpeed = moveSpeed;

    gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
    maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    minJumpVelocity = Mathf.Sqrt(Mathf.Abs(gravity) * minJumpHeight) * 0.75f;
  }

  void Update()
  {
    CalculateVelocity();
    // HandleWallSliding();

    if (canMove)
      controller.Move(velocity * Time.deltaTime, directionalInput);

    if (controller.collisions.above || controller.collisions.below)
    {
      if (controller.collisions.slidingDownMaxSlope)
      {
        velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
      }
      else
      {
        velocity.y = 0;
      }
    }

    if (controller.collisions.below && jumps != 0)
      jumps = 0;
  }

  public void Knockback(Vector3 enterPoint)
  {
    if (reviving)
      return;

    int knockBackForceX = 0;

    if (enterPoint.x <= 0)
    {
      knockBackForceX = knockbackForce;
    }
    else
    {
      knockBackForceX = -knockbackForce;
    }

    velocity.x = knockBackForceX;
    velocity.y = 10;
  }

  public void OnAttackInputDown()
  {
    if (canAttack)
    {
      playerAnimationManager.stateInfo.attacking = true;
      StartCoroutine(AttackRoutine());
    }
  }

  public void OnAttackInputUp()
  {

  }

  private IEnumerator AttackRoutine()
  {
    yield return new WaitForSeconds(0.2f);
    attackHitBox.SetActive(true);
    yield return new WaitForSeconds(0.1f);
    playerAnimationManager.stateInfo.attacking = false;
    yield return new WaitForSeconds(0.1f);
    attackHitBox.SetActive(false);
  }

  public void SetDirectionalInput(Vector2 input)
  {
    directionalInput = input;
  }

  public void OnJumpInputDown()
  {
    if (canJump)
    {
      // if (wallSliding && canWallJump)
      // {
      //   if (wallDirectionX == directionalInput.x)
      //   {
      //     velocity.x = -wallDirectionX * wallJumpClimb.x;
      //     velocity.y = wallJumpClimb.y;
      //   }
      //   else if (directionalInput.x == 0)
      //   {
      //     velocity.x = -wallDirectionX * wallJumpOff.x;
      //     velocity.y = wallJumpOff.y;
      //   }
      //   else
      //   {
      //     velocity.x = -wallDirectionX * wallLeap.x;
      //     velocity.y = wallLeap.y;
      //   }
      // }
      // else 
      if (controller.collisions.below)
      {
        jumps++;
        if (controller.collisions.slidingDownMaxSlope)
        {
          if (directionalInput.x != -Mathf.Sign(controller.collisions.slopeNormal.x))
          { // not jumping against max slope
            velocity.y = maxJumpVelocity * controller.collisions.slopeNormal.y;
            velocity.x = maxJumpVelocity * controller.collisions.slopeNormal.x;
          }
        }
        else
        {
          velocity.y = maxJumpVelocity;
        }
      }
      else if (canDoubleJump && jumps < maxJumps)
      {
        jumps++;
        velocity.y = maxJumpVelocity * 0.80f;
      }
    }
  }

  public void OnJumpInputUp()
  {
    if (velocity.y > minJumpVelocity)
    {
      velocity.y = minJumpVelocity;
    }
  }

  public void OnRunInputDown()
  {
    moveSpeed *= runSpeedIncrease;
  }

  public void OnRunInputUp()
  {
    moveSpeed = baseMoveSpeed;
  }

  // void HandleWallSliding()
  // {
  //   wallDirectionX = (controller.collisions.left) ? -1 : 1;
  //   wallSliding = false;
  //   if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
  //   {
  //     wallSliding = true;

  //     if (velocity.y < -wallSlideSpeedMax)
  //     {
  //       velocity.y = -wallSlideSpeedMax;
  //     }

  //     if (timeToWallUnstick > 0)
  //     {
  //       velocityXSmoothing = 0;
  //       velocity.x = 0;

  //       if (directionalInput.x != wallDirectionX && directionalInput.x != 0)
  //       {
  //         timeToWallUnstick -= Time.deltaTime;
  //       }
  //       else
  //       {
  //         timeToWallUnstick = wallStickTime;
  //       }
  //     }
  //     else
  //     {
  //       timeToWallUnstick = wallStickTime;
  //     }

  //   }

  // }

  public void AdjustHealth(int amount)
  {
    playerData.health += amount;
    if (playerData.health <= 0)
    {
      playerData.health = 0;
      Die();
    }

    if (playerData.health > 8)
      playerData.health = 8;

    playerDisplay.SetHearts();
  }

  public void Die()
  {
    canMove = false;
    canJump = false;
    // canWallJump = false;
    canDoubleJump = false;
    canAttack = false;
    playerAnimationManager.ToggleDeath(true);
    if (!reviving)
      StartCoroutine(ReviveRoutine());
  }

  IEnumerator ReviveRoutine()
  {
    reviving = true;
    yield return new WaitForSeconds(5);
    Revive();
    reviving = false;
  }

  public void Revive()
  {
    canMove = true;
    canJump = true;
    // canWallJump = false;
    canDoubleJump = true;
    canAttack = true;
    LevelManager.instance.ResetPlayer();
    playerAnimationManager.ToggleDeath(false);
    AdjustHealth(8);
  }

  void CalculateVelocity()
  {
    float targetVelocityX = directionalInput.x * moveSpeed;
    velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
    velocity.y += gravity * Time.deltaTime;
  }
}
