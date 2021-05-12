using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparingCoinsForMap : MonoBehaviour
{
	private Rigidbody2D[] _rigidBodies;

	private void Awake()
	{
		_rigidBodies = GetComponentsInChildren<Rigidbody2D>();

		foreach (var rigidBody in _rigidBodies)
		{
			if (rigidBody.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody2D))
			{
				rigidbody2D.bodyType = RigidbodyType2D.Static;
			}
		}
	}
}
