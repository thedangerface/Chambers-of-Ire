using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
  public static LevelManager instance;
  public Vector3 startPos;
  public Vector3 endPos;
  public int startEnemies;
  public int currentEnemies;
  public GameObject player;

  public GameObject levelEnd;

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
    if (currentEnemies == 0)
    {
      FinishLevel();
    }
  }

  public void ResetPlayer()
  {
    player.transform.position = startPos;
  }

  private void FinishLevel()
  {
    levelEnd.SetActive(true);
  }
}
