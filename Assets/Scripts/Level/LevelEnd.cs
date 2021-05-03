using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelEnd : MonoBehaviour
{
  private bool playerIn = false;
  private bool doorOpen = false;
  private void Start()
  {
    StartCoroutine(WaitForOpen());
  }
  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Player")
    {
      playerIn = true;
      if (doorOpen)
        Close();

    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Player")
    {
      playerIn = false;
    }
  }

  private void Close()
  {
    GetComponent<Animator>().SetBool("close", true);
    GameManager.instance.LoadNextLevel();
  }

  IEnumerator WaitForOpen()
  {
    yield return new WaitForSeconds(2);
    doorOpen = true;
    if (playerIn)
      Close();
  }

}
