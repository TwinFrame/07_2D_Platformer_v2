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
			GoToIdle();
		}

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			GoToRight();
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			GoToLeft();
		}

		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			GoToJump();
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			GoToHit();
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

	public void GoToIdle()
	{
		_idle.Invoke();

		if (_countingTimeToRun != null)
			StopCoroutine(CountingTimeToRun());
	}

	public void GoToRight()
	{
		_countingTimeToRun = StartCoroutine(CountingTimeToRun());

		_isRightDirection = true;

		_walk.Invoke(_isRightDirection);
	}

	public void GoToLeft()
	{
		_countingTimeToRun = StartCoroutine(CountingTimeToRun());

		_isRightDirection = false;

		_walk.Invoke(_isRightDirection);
	}

	public void GoToJump()
	{
		_jump.Invoke();
	}

	public void GoToHit()
	{
		_hit.Invoke();
	}

	[System.Serializable]
	public class WalkingEvent : UnityEvent<bool> { }
}
