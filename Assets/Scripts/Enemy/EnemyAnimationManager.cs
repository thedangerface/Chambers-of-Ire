using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    [SerializeField] GameObject runAttack, attack1, attack2, attack3, attack4, superAttack, hitbox;
    [SerializeField] bool flip, facingRight = true;

    private void Update()
    {
        FlipUnit();
    }

    private void FlipUnit()
    {
        if (flip)
        {
            float x = transform.localScale.x;
            float y = transform.localScale.y;
            float z = transform.localScale.z;

            if (x > 0)
            {
                //shift left
                //transform.Translate(Vector3.left * 1.25f);
                facingRight = false;
            }

            else if (x < 0)
            {
                //shift right
                //transform.Translate(Vector3.right * 1.25f);
                facingRight = true;
            }

            transform.localScale = new Vector3(-x, y, z);
            flip = false;
        }
    }

    void Attack1On()
    {
        if (attack1 == null)
        {

        }
        else
            attack1.SetActive(true);
    }

    void Attack1Off()
    {
        if (attack1 == null)
        {

        }
        else
            attack1.SetActive(false);
    }

    void Attack2On()
    {
        if (attack2 == null)
        {

        }
        else
            attack2.SetActive(true);
    }

    void Attack2Off()
    {
        if (attack2 == null)
        {

        }
        else
            attack2.SetActive(false);
    }

    void Attack3On()
    {
        if (attack3 == null)
        {

        }
        else
            attack3.SetActive(true);
    }

    void Attack3Off()
    {
        if (attack3 == null)
        {

        }
        else
            attack3.SetActive(false);
    }

    void Attack4On()
    {
        if (attack4 == null)
        {

        }
        else
            attack4.SetActive(true);
    }

    void Attack4Off()
    {
        if (attack4 == null)
        {

        }
        else
            attack4.SetActive(false);
    }

    void SuperAttackOn()
    {
        if (superAttack == null)
        {

        }
        else
            superAttack.SetActive(true);
    }

    void SuperAttackOff()
    {
        if (superAttack == null)
        {

        }
        else
            superAttack.SetActive(false);
    }

    void RunAttackOn()
    {
        if (runAttack == null)
        {

        }
        else
            runAttack.SetActive(true);
    }

    void RunAttackOff()
    {
        if (runAttack == null)
        {

        }
        else
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
