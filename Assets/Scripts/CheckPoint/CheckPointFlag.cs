using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CheckPointFlag))]

public class CheckPointFlag : MonoBehaviour
{
	public bool isReached { get; private set; }

	public void SetIsReached()
	{
		isReached = true;
	}
}
