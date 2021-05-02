using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
  [SerializeField] float speed = 5f, lifespan = 2f;
  float startTime;
  void Start()
  {
    startTime = Time.time;
  }
  void Update()
  {
    if (transform.localScale.x == 1)
      transform.Translate(Vector3.right * speed * Time.deltaTime);
    else if (transform.localScale.x == -1)
      transform.Translate(Vector3.left * speed * Time.deltaTime);
    if (Time.time - startTime >= lifespan)
      Destroy(gameObject);
  }
}
