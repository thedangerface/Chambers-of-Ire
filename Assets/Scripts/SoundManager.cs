﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
  public AudioSource MusicSource;
  public static SoundManager Instance = null;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    else if (Instance != this)
    {
      Destroy(gameObject);
    }
    DontDestroyOnLoad(gameObject);
  }

  public void PlayMusic(AudioClip clip)
  {
    MusicSource.clip = clip;
    MusicSource.Play();
  }
}