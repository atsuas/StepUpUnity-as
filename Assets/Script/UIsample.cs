using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIsample : MonoBehaviour
{
    [SerializeField]
    private CustomButton _button;

    //[SerializeField]
    //private Image _image;
    //[SerializeField]
    //private Text _text;
    //[SerializeField]
    //private Button _button;

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


        //imageをクリックするとコンソールにClickが出力される
        //_button.onClick.AddListener(() => { Debug.Log("Click"); });


        //アンカーポジションにimageを移動させる
        //_image.rectTransform.anchoredPosition = Vector2.zero;


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
