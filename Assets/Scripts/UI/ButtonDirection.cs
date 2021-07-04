using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonDirection : MonoBehaviour, IPointerDownHandler
{
	[SerializeField] private Button _buttonDirection;
	public void OnPointerDown(PointerEventData eventData)
	{
		_buttonDirection.onClick.Invoke();
	}
}
