using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIsample : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Text _text;
    
    void Start()
    {
        _image.rectTransform.anchoredPosition = Vector2.zero;

        ////imageを300×300に変更する
        //_image.rectTransform.sizeDelta = new Vector2(300f, 300f);
        ////テキストを変更し、カラーをブルーに変更する
        //_text.text = "テキスト変更";
        //_text.color = Color.blue;
    }

    void Update()
    {
        
    }
}
