using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] GameObject runAttack, attack1, attack2, attack3, attack4, superAttack;
    [SerializeField] float timescale = 1;
    [SerializeField] bool flip, facingRight = true;

    private void Start()
    {
        Time.timeScale = timescale;
    }

    private void Update()
    {
        FlipPlayer();
    }

    private void FlipPlayer()
    {
        if (flip)
        {
            float x = transform.localScale.x;
            float y = transform.localScale.y;
            float z = transform.localScale.z;

            if (x > 0)
            {
                //shift left
                transform.Translate(Vector3.left * 1.25f);
                facingRight = false;
            }

            else if (x < 0)
            {
                //shift right
                transform.Translate(Vector3.right * 1.25f);
                facingRight = true;
            }

            transform.localScale = new Vector3(-x, y, z);
            flip = false;
        }
    }

    void Attack1On()
    {
        attack1.SetActive(true);
    }

    void Attack1Off()
    {
        attack1.SetActive(false);
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

    public void RunAttackReposition()
    {
        if (facingRight)
        {
            transform.Translate(Vector3.right * 1.75f);
        }
        else
            transform.Translate(Vector3.left * 1.75f);
    }

    public void SuperAttackReposition()
    {
        if (facingRight)
        {
            transform.Translate(Vector3.left * .48f);
        }
        else
            transform.Translate(Vector3.right * .48f);
    }
}
