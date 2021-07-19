using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private RectTransform _rectTransform;

    public RectTransform rectTransform
    {
        get { return _rectTransform; }
    }

    public int data
    {
        get;
        private set;
    }

    public void Updatedata(int data)
    {
        _text.text = data.ToString();
        this.data = data;
    }
}
