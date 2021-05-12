using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class RoboAnimation : MonoBehaviour
{
	private Animator _animator;

	public void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	private void Start()
	{
		_animator.SetTrigger("Birth");
	}

	public void IdleAnimation()
	{
		_animator.SetBool("Run", false);
		_animator.SetBool("Walk", false);
	}

	public void WalkingAnimation(bool isRightDirection)
	{
		_animator.SetBool("Walk", true);
	}

	public void RunningAnimation()
	{
		_animator.SetBool("Run", true);
	}

	public void Jump()
	{
		_animator.SetTrigger("Jump");
	}

	public void Hit()
	{
		_animator.SetTrigger("Hit");
	}

	public void BirthAnimation()
	{
		_animator.SetTrigger("Birth");
	}
}
