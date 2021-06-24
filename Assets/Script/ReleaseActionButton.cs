using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ReleaseActionButton : MonoBehaviour, IPointerUpHandler
{
    public Action OnReleaseAction;

    //リリース時のアクション
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if (enabled == false)
        {
            return;
        }
        if (OnReleaseAction != null)
        {
            OnReleaseAction();
        }
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
