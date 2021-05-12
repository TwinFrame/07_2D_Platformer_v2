using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoboInput : MonoBehaviour
{
	[SerializeField] private float _timeToRunning;
	[SerializeField] private UnityEvent _idle;
	[SerializeField] private WalkingEvent _walk;
	[SerializeField] private UnityEvent _run;
	[SerializeField] private UnityEvent _jump;
	[SerializeField] private UnityEvent _hit;

	private bool _isRightDirection;
	private float _runningTime;
	private Coroutine _countingTimeToRun;

	private void Update()
	{
		if (!Input.anyKey || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
		{
			_idle.Invoke();

			if (_countingTimeToRun != null)
				StopCoroutine(CountingTimeToRun());
		}

		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			_countingTimeToRun = StartCoroutine(CountingTimeToRun());

			if (Input.GetKey(KeyCode.RightArrow))
				_isRightDirection = true;
			else if (Input.GetKey(KeyCode.LeftArrow))
				_isRightDirection = false;

			_walk.Invoke(_isRightDirection);
		}

		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			_jump.Invoke();
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			_hit.Invoke();
		}
	}

	private IEnumerator CountingTimeToRun()
	{
		_runningTime = 0;

		while (_runningTime <= _timeToRunning)
		{
			_runningTime += Time.deltaTime;

			yield return null;
		}

		_run.Invoke();
	}

	[System.Serializable]
	public class WalkingEvent : UnityEvent<bool> { }
}
