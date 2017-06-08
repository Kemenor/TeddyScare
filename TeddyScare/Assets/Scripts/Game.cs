using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

	public void Start()
	{
		DontDestroyOnLoad(this);
	}

	public void Update()
	{
		if (Input.GetKey(KeyCode.O))
		{
			NextLevel();
		}
		if (Input.GetKey(KeyCode.Escape))
		{
			LoadLevel(0);
		}
	}
	private static Player player;
	public static Player Player
	{
		get
		{
			if (player == null)
			{
				player = GameObject.FindObjectOfType<Player>();
			}
			return player;
		}
	}

	private static int levelNumber = 0;
	public Level Level { get; private set; }

	public void NextLevel()
	{
		LoadLevel(levelNumber + 1);
	}

	public void LoadLevel(int level)
	{
		if (level == 0)
		{
			levelNumber = 0;
			Level = null;
			SceneManager.LoadScene("MainMenu");
		}
		else
		{
			int dangerRating = 0;
			if (Level != null)
				dangerRating = Level.DangerLevel / 2;
			levelNumber = level;
			SceneManager.LoadScene("Bear" + levelNumber);
			foreach (var item in SceneManager.GetActiveScene().GetRootGameObjects())
			{
				if (item.CompareTag("Level"))
				{
					this.Level = item.GetComponent<Level>();
					Level.SetInitialDanger(dangerRating);
					break;
				}
			}
		}
	}
}
