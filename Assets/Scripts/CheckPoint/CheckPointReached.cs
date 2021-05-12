using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPointReached : MonoBehaviour
{
    [SerializeField] private UnityEvent _checkPointIsReached;

    private CheckPointFlag _checkPointFlag;

    private void Awake()
    {
        _checkPointFlag = GetComponentInChildren<CheckPointFlag>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_checkPointFlag.isReached && collision.TryGetComponent<Robo>(out Robo robo))
        {
            _checkPointIsReached.Invoke();
        }
    }
}
