using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  private static GameManager _instance;
  public static GameManager instance { get { return _instance; } }

  // list of all levels
  public List<string> allLevels = new List<string> {
    "1-1",
    "1-2",
    "1-3",
    "1-4",
    "2-1",
    "2-2",
    "2-3",
    "2-4",
    "3-1",
  };
  public int currentLevelIndex = 0;

  private void Awake()
  {
    DontDestroyOnLoad(gameObject);

    if (_instance != null && _instance != this)
    {
      Destroy(this.gameObject);
    }
    else
    {
      _instance = this;
    }
  }

  public void RestartLevel()
  {
    LoadScene(allLevels[currentLevelIndex]);
  }

  public void LoadScene(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }

  public void LoadNextLevel()
  {
    currentLevelIndex++;
    LoadScene(allLevels[currentLevelIndex]);
  }

}
