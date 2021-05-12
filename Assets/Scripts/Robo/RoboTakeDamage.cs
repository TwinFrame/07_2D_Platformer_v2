using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoboTakeDamage : MonoBehaviour
{
	[SerializeField] private TakeDamageEvent _takeDamage;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
		{
			_takeDamage.Invoke(enemy.GetDamage());
		}
	}
}

[System.Serializable]
public class TakeDamageEvent : UnityEvent<int> { }
