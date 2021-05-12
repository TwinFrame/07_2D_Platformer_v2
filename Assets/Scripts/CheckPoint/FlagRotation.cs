using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlagRotation : MonoBehaviour
{
    [SerializeField] private float _timeFlagRotation;

    private CheckPointFlag _checkPointFlag;

    private void Start()
    {
        _checkPointFlag = GetComponentInChildren<CheckPointFlag>();
    }

    public void FlagLoopRotaion()
    {
        _checkPointFlag.transform.DORotate(new Vector3(0, 0, 360), _timeFlagRotation)
            .SetOptions(false).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }
}
