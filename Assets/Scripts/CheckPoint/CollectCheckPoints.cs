using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectCheckPoints : MonoBehaviour
{
	[SerializeField] private UnityEvent _finished;

	private CheckPointFlag[] _checkPointFlags;
	private bool _isCollectedAllCheckpoint;

	private void Start()
	{
		_checkPointFlags = GetComponentsInChildren<CheckPointFlag>();
	}

	private void LateUpdate()
	{
		if (!_isCollectedAllCheckpoint)
			_isCollectedAllCheckpoint = CollectedAllCheckPoints();
	}

	public bool CollectedAllCheckPoints()
	{
		foreach (var flag in _checkPointFlags)
		{
			if (!flag.GetIsReached())
			{
				return false;
			}
		}

		_finished.Invoke();

		return true;
	}
}
