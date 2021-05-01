using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
  [SerializeField] GameObject runAttack, attack1, attack2, attack3, attack4, superAttack, hitbox;
  [SerializeField] float timescale = 1;
  [SerializeField] Animator animator;

  PlayerState playerState;

  private void Start()
  {
    playerState = GetComponent<PlayerState>();
    playerState.Set(PlayerState.State.facingRight, true);
    Physics2D.IgnoreLayerCollision(9, 10);
  }

  private void Update()
  {
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
    playerState.Set(PlayerState.State.attacking, false);
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
    animator.SetBool("dead", toggle);
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
}
