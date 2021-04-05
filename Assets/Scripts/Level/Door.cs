using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Door : MonoBehaviour
{
    [SerializeField] Transform exit;
    bool moving;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //run coroutine to trigger animation, then move player
            collision.gameObject.transform.position = exit.transform.position;
            moving = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && moving == false)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                //run coroutine to trigger animation, then move player
                collision.gameObject.transform.position = exit.transform.position;
                moving = true;
            }
        }
    }

}
