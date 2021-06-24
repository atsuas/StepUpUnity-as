using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    //ドラッグ開始時処理
    public Action OnBeginDragAction;
    //ドラッグ中処理
    public Action OnDragAction;
    //ドラッグ終了処理
    public Action OnEndDragAction;

    private CanvasGroup _canvasGroup;
    private Vector3 _startPosition;
    private Camera _uiCamera;

    private void Awake()
    {
        _canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }

    private void OnDestroy()
    {
        OnBeginDragAction = null;
        OnDragAction = null;
        OnEndDragAction = null;
        _uiCamera = null;
    }

    public void SetScreenSpaceCamera(Camera uiCamera)
    {
        _uiCamera = uiCamera;
    }

    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        if (enabled == false)
        {
            return;
        }

        //ドロップ判定が取れるように
        _canvasGroup.blocksRaycasts = false;

        _startPosition = transform.position;

        if (OnBeginDragAction != null)
        {
            OnBeginDragAction();
        }
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        if (enabled == false)
        {
            return;
        }

        if (_uiCamera != null)
        {
            var position = _uiCamera.ScreenToWorldPoint(pointerEventData.position);
            position.z = transform.position.z;
            transform.position = position;
        }
        else
        {
            transform.position = pointerEventData.position;
        }

        if (OnDragAction != null)
        {
            OnDragAction();
        }
    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        _canvasGroup.blocksRaycasts = true;

        transform.position = _startPosition;

        if (enabled == false)
        {
            return;
        }

        if (OnEndDragAction != null)
        {
            OnEndDragAction();
        }
    }

}
