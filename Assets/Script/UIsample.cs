using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIsample : MonoBehaviour
{
    [SerializeField]
    private CustomButton _button;

    //Use this for intialization
    void Start()
    {
        _button.OnClickAction = () =>
        {
            Debug.Log("Click");
        };
        _button.OnLongPressAction = () =>
        {
            Debug.Log("LongPress");
        };

    }

    void Update()
    {
        
    }
}
