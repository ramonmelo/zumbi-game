using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance { get; private set; }
	
	public GameObject UI_GameOver;

	public event Action OnGameOver;

    void Awake()
    {
		if (instance != null)
		{
			Destroy(instance.gameObject);
		}

		instance = this;

		OnGameOver += GameOverHandler;
	}

	private void GameOverHandler()
	{
		Time.timeScale = 0;
		UI_GameOver.SetActive(true);
	}

	// Raise Events

	public void RaiseRestart()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void RaiseGameOver()
	{
		OnGameOver();
	}
}