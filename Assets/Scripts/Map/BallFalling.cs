using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFalling : MonoBehaviour
{
	[SerializeField] private float _duration;
	[SerializeField] private GameObject _object;

	private WaitForSeconds _waitingTime;
	private Coroutine _periodicallyInstantiated;
	private Collider2D _deathZone;

	private void Awake()
	{
		_deathZone = GetComponentInChildren<BoxCollider2D>();
	}

	private void Start()
	{
		_waitingTime = new WaitForSeconds(_duration);

		_periodicallyInstantiated = StartCoroutine(PeriodicallyInstantiateObject(_object));
	}

	private IEnumerator PeriodicallyInstantiateObject(GameObject gameObject)
	{
		while (true)
		{
			Instantiate(gameObject, transform);

			yield return _waitingTime;
		}
	}
}
