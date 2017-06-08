using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
	[SerializeField]
	private Collider2D other;
	[SerializeField]
	private Collider2D[] moreIgnore;
	// Use this for initialization
	private void Awake()
	{
		Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other, true);
		foreach (var item in moreIgnore)
		{
			Physics2D.IgnoreCollision(item, other, true);
		}
	}
}
