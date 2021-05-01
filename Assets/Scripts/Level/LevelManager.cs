using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
  public static LevelManager instance;
  public Vector3 startPos;
  public Vector3 endPos;
  public int totalEnemies;
  public int currentEnemies;
  public GameObject player;

  private void Awake()
  {
    instance = this;
  }

  private void Start()
  {
    currentEnemies = currentEnemies;
  }
  public void DecrementEnemies()
  {
    currentEnemies--;
  }

  public void ResetPlayer()
  {
    player.transform.position = startPos;
  }

  public void FinishLevel()
  {

  }
}
