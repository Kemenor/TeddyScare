using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	private static Game instance;
	public static Game Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<Game>();
			}
			return instance;
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
	[SerializeField]
	private int dangerLevel;
	[SerializeField]
	private Character[] characters;

	[SerializeField]
	private Character[] level0Activate;

	[SerializeField]
	private Character[] level0Deactivate;

	[SerializeField]
	private Character[] level1Activate;

	[SerializeField]
	private Character[] level2Activate;

	[SerializeField]
	private Character[] level3Activate;

	[SerializeField]
	private Character[] level1Deactivate;

	[SerializeField]
	private Character[] level2Deactivate;

	[SerializeField]
	private Character[] level3Deactivate;


	public void ResetAll()
	{
		foreach (var item in characters)
		{
			item.Reset();
		}
	}

	public void KillPlayer()
	{
		player.Anim.SetTrigger("Death");
	}

	public void AddToDangerLevel(int danger = 1)
	{
		SetDangerRating(dangerLevel + danger);
	}

	protected void SetDangerRating(int dangerRating)
	{
		this.dangerLevel = dangerRating;
		switch (dangerLevel)
		{
			case 0:
				foreach (var item in level0Activate)
				{
					item.gameObject.SetActive(true);
				}
				foreach (var item in level0Deactivate)
				{
					item.gameObject.SetActive(false);
				}
				break;
			case 1:
				foreach (var item in level1Activate)
				{
					item.gameObject.SetActive(true);
				}
				foreach (var item in level1Deactivate)
				{
					item.gameObject.SetActive(false);
				}
				break;
			case 2:
				foreach (var item in level2Activate)
				{
					item.gameObject.SetActive(true);
				}
				foreach (var item in level2Deactivate)
				{
					item.gameObject.SetActive(false);
				}
				break;
			default:
				foreach (var item in level3Activate)
				{
					item.gameObject.SetActive(true);
				}
				foreach (var item in level3Deactivate)
				{
					item.gameObject.SetActive(false);
				}
				break;
		}
	}
}
