using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelEnd : MonoBehaviour
{
  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Player")
    {
      if (Input.GetKeyDown(KeyCode.W))
      {
        Debug.Log("bottom");
        // trigger close animation
        GetComponent<Animator>().SetBool("close", true);
        // trigger player walk in animation
        // end level
        GameManager.instance.LoadNextLevel();
      }
    }
  }

}
