using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public int health = 1;

  private void Start()
  {

  }

  public void TakeDamage(int damage)
  {
    health -= damage;

    if (health <= 0)
    {
      Die();
    }
  }

  public void Die()
  {
    Destroy(this.gameObject);
    LevelManager.instance.DecrementEnemies();
  }
}
