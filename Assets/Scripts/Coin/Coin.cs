using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Coin))]
[RequireComponent(typeof(CircleCollider2D))]

public class Coin : MonoBehaviour
{
	[SerializeField] private int _nominalValue;
	[SerializeField] private float _speedDefaultRotation;
	[SerializeField] private AudioClip _collectedSound;

	private Coroutine _defaultRotationJob;

	public int nominalValue
	{
		get
		{
			return _nominalValue;
		}
	}

	public AudioClip collectedSound
	{
		get
		{
			return _collectedSound;
		}
	}

	private void OnEnable()
	{
		_defaultRotationJob = StartCoroutine(DefaultRotation());
	}

	private IEnumerator DefaultRotation()
	{
		while (true)
		{
			transform.Rotate(new Vector3(0, 1, 0), _speedDefaultRotation * Time.deltaTime);

			yield return null;
		}
	}
}
