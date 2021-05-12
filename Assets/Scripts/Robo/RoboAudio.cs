using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboAudio : MonoBehaviour
{
	private AudioSource _audioSource;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
	}

	public void PlayFootsteps(bool direction)
	{
		_audioSource.pitch = 1f;
		_audioSource.Play();
	}

	public void PitchUp(float value)
	{
		_audioSource.pitch = value;
	}
}
