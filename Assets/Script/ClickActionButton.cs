using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ClickActionButton : MonoBehaviour, IPointerClickHandler
{
    public Action OnClickAction;

    //クリック時のアクション
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (enabled == false)
        {
            return;
        }
        if (OnClickAction != null)
        {
            OnClickAction();
        }
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
