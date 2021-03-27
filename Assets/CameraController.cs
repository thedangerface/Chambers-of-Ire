using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float xMin, xMax, yMin, yMax;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float targetX = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}
