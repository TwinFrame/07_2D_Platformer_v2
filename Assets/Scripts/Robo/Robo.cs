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

	private Vector3 respawnPosition;
	private int _health;
	private int _wallet;

	private void OnEnable()
	{
		_health = _fullHealth;

		respawnPosition = transform.localPosition;
	}

	public void AddCoin(int value)
	{
		_wallet += value;

		Debug.Log($"Кашель: {_wallet} (+{value})");
	}

	public void TakeDamage(int damage)
	{
		_health -= damage;

		if (_health <= 0)
		{
			_health = _fullHealth;

			transform.localPosition = respawnPosition;

			RespawnPlayerAfterDeath();

			Debug.Log("Вы проиграли.");

			return;
		}

		Debug.Log($"Здоровье: {_health} (-{damage})");
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
