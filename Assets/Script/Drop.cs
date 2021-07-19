using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    //ドロップ範囲に入ったときの処理
    public Action OnPointerEnterAction;
    //ドロップ範囲内から出たときの処理
    public Action OnPointerExitAction;
    //ドロップ時処理
    public Action OnDropAction;

    private void OnDestroy()
    {
        OnPointerEnterAction = null;
        OnPointerExitAction = null;
        OnDropAction = null;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (OnPointerEnterAction != null)
        {
            OnPointerEnterAction();
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (OnPointerExitAction != null)
        {
            OnPointerExitAction();
        }
    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        if (OnDropAction != null)
        {
            OnDropAction();
        }
    }
}
