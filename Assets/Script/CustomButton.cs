using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

[RequireComponent(typeof(LongPressTrigger))]
public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Action OnClickAction;
    public Action OnPressAction;
    public Action OnReleaseAction;
    public Action OnLongPressAction;

    private bool _isLongPress;

    private void Awake()
    {
        var longPressTrigger = gameObject.GetComponent<LongPressTrigger>();
        longPressTrigger.AddLongPressAction(OnLongPress);
    }

    private void OnDestroy()
    {
        OnClickAction = null;
        OnPressAction = null;
        OnReleaseAction = null;
        OnLongPressAction = null;
    }

    //プレス時のアクション
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (enabled == false)
        {
            return;
        }
        if (OnPressAction != null)
        {
            OnPressAction();
        }
        _isLongPress = false;
    }

    //クリック時のアクション
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (enabled == false)
        {
            return;
        }
        if (_isLongPress == false && OnClickAction != null)
        {
            OnClickAction();
        }
    }

    //リリース時のアクション
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if (enabled == false)
        {
            return;
        }
        if (_isLongPress == false && OnReleaseAction != null)
        {
            OnReleaseAction();
        }
    }

    //長押し時のアクション
    public virtual void OnLongPress()
    {
        if (enabled == false)
        {
            return;
        }
        if (OnLongPressAction != null)
        {
            OnLongPressAction();
        }
        _isLongPress = true;
    }

}
