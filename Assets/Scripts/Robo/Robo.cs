using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Robo))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]

public class Robo : MonoBehaviour
{
	[SerializeField] private int _fullHealth;
	[SerializeField] private UnityEvent _deathEvent;

	public int health { get; private set; }
	public int wallet { get; private set; }

	private Vector3 respawnPosition;

	private void OnEnable()
	{
		health = _fullHealth;

		respawnPosition = transform.localPosition;
	}

	public void AddCoin(int value)
	{
		wallet += value;
	}

	public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			health = _fullHealth;

			transform.localPosition = respawnPosition;

			RespawnPlayerAfterDeath();

			Debug.Log("Вы проиграли.");

			return;
		}
	}

	public void ChangeResapwnPosition()
	{
		respawnPosition = transform.position;
	}

	public void RespawnPlayerAfterDeath()
	{
		transform.localPosition = respawnPosition;

		_deathEvent.Invoke();
	}
}
