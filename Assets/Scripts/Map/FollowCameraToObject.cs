using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraToObject : MonoBehaviour
{
	[SerializeField] GameObject _trackingObject;

	private Vector3 _startPosition;
	private Vector3 _currentPosition;

	private void Start()
	{
		_startPosition = transform.position;
	}

	private void LateUpdate()
	{
		_currentPosition = _startPosition + _trackingObject.transform.position;

		transform.SetPositionAndRotation(_currentPosition, Quaternion.identity);
	}
}
