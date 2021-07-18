using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    [SerializeField]
    private Cell _cellPrefab;
    [SerializeField]
    private int _instantateCellCount;
    [SerializeField]
    private ScrollRect _scrollRect;
    [SerializeField]
    private float _cellHeight = -1f;

    private LinkedList<Cell> _cellList = new LinkedList<Cell>();

    private List<int> _dataList = new List<int>();

    private float _lastContentPositionY = 0f;
    private int _index;
    
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            _dataList.Add(i);
        }

        for (int i = 0; i < _instantateCellCount; i++)
        {
            var item = Instantiate(_cellPrefab, _scrollRect.content);

            //上詰めするためにAnchorを設定
            item.rectTransform.anchorMin = new Vector2(0.5f, 1f);
            item.rectTransform.anchorMax = new Vector2(0.5f, 1f);

            //_cellHeight / 2fはPivotの差分
            item.rectTransform.anchoredPosition = new Vector2(0f, -_cellHeight * i + _cellHeight / 2f);

            item.Updatedata(GetDataIndex(i));

            _cellList.AddLast(item);
        }

        _scrollRect.horizontal = false;
        _scrollRect.vertical = true;
        _scrollRect.movementType = ScrollRect.MovementType.Unrestricted;
        _lastContentPositionY = _scrollRect.content.anchoredPosition.y;
    }

    void Update()
    {
        if (_cellList.Count == 0)
        {
            return;
        }

        float diff = Mathf.Clamp(_scrollRect.content.anchoredPosition.y - _lastContentPositionY, -_cellHeight, _cellHeight);

        //スクロールの差分がセルの高さを超えたらセルの移動処理
        if (Mathf.Abs(diff) >= _cellHeight)
        {
            _lastContentPositionY += diff;

            var first = _cellList.First.Value;
            var last = _cellList.Last.Value;

            if (diff > 0f)
            {
                //上方向へのスクロール
                //一番上の要素を一番下に移動
                _cellList.RemoveFirst();
                _cellList.AddLast(first);

                first.rectTransform.anchoredPosition = new Vector2(0f, last.rectTransform.anchoredPosition.y - _cellHeight);

                first.Updatedata(GetDataIndex(_index + _instantateCellCount));
                _index++;
            }
            else
            {
                //下方向へのスクロール
                //一番下の要素を一番上に移動
                _cellList.RemoveLast();
                _cellList.AddFirst(last);

                last.rectTransform.anchoredPosition = new Vector2(0f, first.rectTransform.anchoredPosition.y + _cellHeight);

                _index--;
                last.Updatedata(GetDataIndex(_index));
            }
        }
    }

    private int GetDataIndex(int index)
    {
        if (index >= 0 && _dataList.Count > index)
        {
            return _dataList[index];
        }

        //下に追加した要素のデータ
        //前のデータを取得
        if (index < 0)
        {
            return _dataList[_dataList.Count + (index + 1) % _dataList.Count - 1];
        }

        return index;
    }
}
