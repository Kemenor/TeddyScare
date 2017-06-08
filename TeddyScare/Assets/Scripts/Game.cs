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
		int dangerRating = 0;
		if (Level != null)
			dangerRating = Level.DangerLevel;
		levelNumber++;
		SceneManager.LoadScene("Bear" + levelNumber);
		foreach (var item in SceneManager.GetActiveScene().GetRootGameObjects())
		{
			if (item.CompareTag("Level"))
			{
				this.Level = item.GetComponent<Level>();
				Level.SetInitialDanger(dangerRating);
			}
		}
	}
}
