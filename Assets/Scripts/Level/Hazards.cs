using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{

  public int damage;
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Player")
    {
      Vector3 enterPoint = transform.position - collision.transform.position;
      Player player = collision.GetComponent<Player>();
      player.AdjustHealth(damage);
      player.Knockback(enterPoint);
    }
  }
}
