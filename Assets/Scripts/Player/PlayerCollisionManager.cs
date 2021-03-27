using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered: " + collision.gameObject.name);
        if (collision.gameObject.tag == "enemy attack box")
        {
            if (animator == null)
                return;

            animator.SetTrigger("damaged");
        }
    }
}
