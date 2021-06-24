using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class LongPressTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    //長押しと判定する時間
    public float IntervalSecond = 1f;

    //長押し時に発火するアクション
    private Action _onLongPointerDown;

    private float _executeTime;

    private void Update()
    {
        if (_executeTime > 0f && _executeTime <= Time.realtimeSinceStartup)
        {
            _onLongPointerDown();
            _executeTime = -1f;
        }
    }

    private void OnDestroy()
    {
        _onLongPointerDown = null;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //押下時に長押しが発火する時間を設定
        _executeTime = Time.realtimeSinceStartup + IntervalSecond;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _executeTime = -1f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _executeTime = -1f;
    }

    public void AddLongPressAction(Action action)
    {
        _onLongPointerDown = action;
    }
}
