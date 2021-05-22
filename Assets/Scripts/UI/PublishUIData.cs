using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PublishUIData : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsCount;
    [SerializeField] private TMP_Text _healthCount;
	[SerializeField] private Robo _robo;

	public void PublishCoins()
	{
		_coinsCount.text = _robo.wallet.ToString();
	}

	public void PublishHealth(int value)
	{
		_healthCount.text = _robo.health.ToString();
	}

	private void Start()
	{
		PublishCoins();
		PublishHealth(_robo.health);
	}
}
