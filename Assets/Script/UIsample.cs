using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIsample : MonoBehaviour
{
    [SerializeField]
    private Drag _drag;
    [SerializeField]
    private Drop _drop;

    //Use this for intialization
    void Start()
    {
        _drop.OnDropAction = () =>
        {
            var dropImage = _drop.GetComponent<Image>();
            var dragImage = _drag.GetComponent<Image>();
            dropImage.color = dragImage.color;
        };
    }

}
