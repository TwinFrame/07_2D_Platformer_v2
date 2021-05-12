using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsRespawner : MonoBehaviour
{
	[SerializeField] private int _countCoins;
	[SerializeField] private float _duration;
	[SerializeField] private Coin[] _coins;

	private int _currentCoinNumber;
	private Vector2 _currentForce;
	private WaitForSeconds _waitForDurationSeconds;
	private Coroutine _startCoinsSpawner;
	private int _countCoinsSpawned;

	private void OnEnable()
	{
		_waitForDurationSeconds = new WaitForSeconds(_duration);
	}

	public void StartCoinsSpawner()
	{
		if (_startCoinsSpawner != null)
		{
			StopCoroutine(_startCoinsSpawner);
		}

		_startCoinsSpawner = StartCoroutine(PeriodicallyCoinsSpawner());
	}

	private IEnumerator PeriodicallyCoinsSpawner()
	{
		while (_countCoinsSpawned <= _countCoins)
		{
			_currentForce.Set(Random.Range(-300f, 300f), 0);
			_currentCoinNumber = Random.Range(0, _coins.Length);

			var _currentCoin = Instantiate(_coins[_currentCoinNumber], transform.localPosition, Quaternion.identity);

			_currentCoin.GetComponent<Rigidbody2D>().AddForce(_currentForce);

			_countCoinsSpawned++;

			yield return _waitForDurationSeconds;
		}
	}
}
