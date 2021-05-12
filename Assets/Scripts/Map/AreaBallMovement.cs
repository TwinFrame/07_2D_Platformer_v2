using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBallMovement : MonoBehaviour
{
	[SerializeField] private float _forceMagnitude;

	private AreaEffector2D[] _areaEffector2Ds;

	private void Awake()
	{
		_areaEffector2Ds = GetComponentsInChildren<AreaEffector2D>();

		foreach (var areaEffector in _areaEffector2Ds)
		{
			areaEffector.forceMagnitude = _forceMagnitude;
		}
	}
}
