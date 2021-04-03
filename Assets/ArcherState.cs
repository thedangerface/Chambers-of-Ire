using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherState : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab, arrowExit;
    GameObject player;
    bool faceRight = true, lastFaceRight = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        SetDirection();
    }

    private void SetDirection()
    {
        lastFaceRight = faceRight;
        if (transform.position.x > player.transform.position.x)
        {
            faceRight = false;
        }
        else if (transform.position.x < player.transform.position.x)
        {
            faceRight = true;
        }
        if (lastFaceRight != faceRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x, 
                transform.localScale.y, transform.localScale.z);
        }
    }

    public void FireArrow()
    {
        Vector3 position = new Vector3(arrowExit.transform.position.x,
            arrowExit.transform.position.y, arrowExit.transform.position.z);
        GameObject arrow = GameObject.Instantiate(arrowPrefab, position, Quaternion.identity);

        if (faceRight)
            arrow.transform.localScale = new Vector3(1,
                arrow.transform.localScale.y, arrow.transform.localScale.z);
        else
            arrow.transform.localScale = new Vector3(-1,
                arrow.transform.localScale.y, arrow.transform.localScale.z);
    }
}
