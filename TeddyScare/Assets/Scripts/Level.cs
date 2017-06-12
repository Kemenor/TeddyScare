using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

	private static Level instance;
	public static Level Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<Level>();
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
	private int initialRating = 0;

	[SerializeField]
	public int DangerLevel { get; private set; }
	[SerializeField]
	private Character[] characters;

	[SerializeField]
	private Character[] level0Activate;

	[SerializeField]
	private Character[] level0Deactivate;

	[SerializeField]
	private Character[] level1Activate;

	internal void SetInitialDanger(int dangerRating)
	{
		if (initialRating == 0)
		{
			initialRating = dangerRating;
			SetDangerRating(dangerRating);
		}
	}

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
            if (item.gameObject.activeInHierarchy)
            {
                item.Reset();
            }
		}
		SetDangerRating(initialRating);
	}

	public void KillPlayer()
	{
		player.Anim.SetTrigger("Death");
	}

	public void AddToDangerLevel(int danger = 1)
	{
		SetDangerRating(DangerLevel + danger);
	}

	protected void SetDangerRating(int dangerRating)
	{
		this.DangerLevel = dangerRating;
		switch (DangerLevel)
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