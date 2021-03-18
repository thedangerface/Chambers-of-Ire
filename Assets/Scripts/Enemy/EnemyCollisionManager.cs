using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger entered: " + collision.gameObject.name);
        if (collision.gameObject.tag == "attack box")
        {
            animator.SetTrigger("damaged");
        }
    }
}
