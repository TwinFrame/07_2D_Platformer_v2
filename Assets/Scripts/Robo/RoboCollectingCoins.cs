using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoboCollectingCoins : MonoBehaviour
{
	[SerializeField] private UnityEvent _collectedCoinEvent;

	private Coin _coin;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.TryGetComponent<CoinTrigger>(out CoinTrigger coinTrigger))
		{
			_coin = coinTrigger.GetComponentInParent<Coin>();

			GetComponent<Robo>().AddCoin(_coin.nominalValue);

			GetComponent<AudioSource>().PlayOneShot(_coin.collectedSound);

			Destroy(_coin.gameObject);

			_collectedCoinEvent.Invoke();
		}
	}
}
