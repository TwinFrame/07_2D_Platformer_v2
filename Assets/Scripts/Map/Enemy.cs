using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class Enemy : MonoBehaviour
{
	[SerializeField] private int _damage;

	public int damage
	{
		get
		{
			return _damage;
		}
	}
}
