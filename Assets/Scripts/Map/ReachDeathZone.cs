using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

public class ReachDeathZone : MonoBehaviour
{
	[SerializeField] private UnityEvent _birthEvent;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<Robo>(out Robo Robo))
		{
			_birthEvent.Invoke();

			return;
		}

		Destroy(collision.gameObject);
	}
}
