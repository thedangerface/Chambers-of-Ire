using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
  [SerializeField] GameObject runAttack, attack1, attack2, attack3, attack4, superAttack, hitbox;
  [SerializeField] float timescale = 1;
  public enum State { idle, running, jumping, falling, damaged, landing, runningAttack, attacking, wallSliding, wallJump }
  public State animationState;
  public StateInfo stateInfo;
  [SerializeField] Animator animator;
  public bool alive = true;

  private void Start()
  {
    stateInfo = new StateInfo();
    stateInfo.facingRight = true;
    stateInfo.facingRightOld = true;
    Physics2D.IgnoreLayerCollision(9, 10);
  }

  private void Update()
  {
    if (alive)
      CheckState();
    Time.timeScale = timescale;
  }

  private void FlipPlayer()
  {
    float x = transform.localScale.x;
    float y = transform.localScale.y;
    float z = transform.localScale.z;
    transform.localScale = new Vector3(-x, y, z);
  }

  void Attack1On()
  {
    attack1.SetActive(true);
  }

  void Attack1Off()
  {
    attack1.SetActive(false);
  }

  void Attack1End()
  {
    stateInfo.attacking = false;
  }
  void Attack1RunningOn()
  {
    attack1.SetActive(true);
  }

  void Attack1RunningOff()
  {
    attack1.SetActive(false);
  }

  void Attack1RunningEnd()
  {
    animator.SetBool("attack1running", false);
    stateInfo.attacking = false;
  }

  void Attack2On()
  {
    attack2.SetActive(true);
  }

  void Attack2Off()
  {
    attack2.SetActive(false);
  }

  void Attack3On()
  {
    attack3.SetActive(true);
  }

  void Attack3Off()
  {
    attack3.SetActive(false);
  }

  void Attack4On()
  {
    attack4.SetActive(true);
  }

  void Attack4Off()
  {
    attack4.SetActive(false);
  }

  void SuperAttackOn()
  {
    superAttack.SetActive(true);
  }

  void SuperAttackOff()
  {
    superAttack.SetActive(false);
  }

  void RunAttackOn()
  {
    runAttack.SetActive(true);
  }

  void RunAttackOff()
  {
    runAttack.SetActive(false);
  }
  public void ToggleDeath(bool toggle)
  {
    alive = !toggle;
    ResetAnimator();
    animator.SetBool("idle", true);
    animator.SetBool("dead", toggle);
  }

  public void RunAttackReposition()
  {
    //if (facingRight)
    //{
    //    transform.Translate(Vector3.right * 1.75f);
    //}
    //else
    //    transform.Translate(Vector3.left * 1.75f);
  }

  public void SuperAttackReposition()
  {
    //if (facingRight)
    //{
    //    transform.Translate(Vector3.left * .48f);
    //}
    //else
    //    transform.Translate(Vector3.right * .48f);
  }

  // State Machine

  public void CheckState()
  {
    ResetAnimator();
    stateInfo.facingRightOld = stateInfo.facingRight;

    // are we damaged?
    if (stateInfo.damaged)
    {
      animationState = State.damaged;
    }

    // are we grounded?
    else if (stateInfo.collisionsBelow)
    {
      // did we just land?
      if (stateInfo.collisionsBelowOld != stateInfo.collisionsBelow)
      {
        animationState = State.landing;
        SetAnimatorState("landing");
      }

      // are we moving horizontally?
      else if (Mathf.Abs(stateInfo.velocity.x) > 0.001f)
      {
        if (stateInfo.attacking)
        {
          // attack 1 running
          animationState = State.runningAttack;
          SetAnimatorState("attack1running");
        }
        else
        {
          // state = running
          animationState = State.running;
          SetAnimatorState("running");
        }
      }
      else if (stateInfo.velocity.x <= 0.001f)
      {
        if (stateInfo.attacking)
        {
          GroundAttackTree();
        }
        else
        {
          animationState = State.idle;
          SetAnimatorState("idle");
        }
      }
    }

    // are we in the air
    else if (!stateInfo.collisionsBelow)
    {
      if (stateInfo.attacking)
      {
        animationState = State.attacking;
        GroundAttackTree();
      }

      else if (stateInfo.velocity.y > 0)
      {
        // we are jumping
        animationState = State.jumping;
        SetAnimatorState("jumping");
      }

      else if (stateInfo.velocity.y < 0)
      {
        // we are falling
        animationState = State.falling;
        SetAnimatorState("falling");
      }


    }

    // flip animation 
    {
      if (Input.GetAxisRaw("Horizontal") > 0)
        stateInfo.facingRight = true;
      else if (Input.GetAxisRaw("Horizontal") < 0)
        stateInfo.facingRight = false;
      if (stateInfo.facingRight != stateInfo.facingRightOld)
        FlipPlayer();
    }
  }

  private void GroundAttackTree()
  {
    animationState = State.attacking;
    // which attack? 

    // dash will be considered an attack - even if we decide it doesn't damage. 

    // attack 1
    SetAnimatorState("attack1");
    // attack 2

    // attack 3

    // attack 4

    // super attack
  }

  void ResetAnimator()
  {
    animator.SetBool("idle", false);
    animator.SetBool("running", false);
    animator.SetBool("jumping", false);
    animator.SetBool("falling", false);
    animator.SetBool("landing", false);
    animator.SetBool("attack1", false);
    animator.SetBool("attack1running", false);
  }

  void SetAnimatorState(string state)
  {
    animator.SetBool(state, true);
  }

  public struct StateInfo
  {
    public bool collisionsBelow;
    public bool collisionsBelowOld;
    public bool damaged;
    public bool attacking;
    public bool attackingOld;
    public Vector2 velocity;
    public bool facingRight;
    public bool facingRightOld;
  }
}
