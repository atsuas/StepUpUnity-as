using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    [SerializeField]
    private RectTransform _cellPrefab;
    [SerializeField]
    private int _instantateCellCount;
    [SerializeField]
    private ScrollRect _scrollRect;
    [SerializeField]
    private float _cellHeight;

    private LinkedList<RectTransform> _cellList = new LinkedList<RectTransform>();

    private float _lastContentPositionY = 0f;
    
    void Start()
    {
        for (int i = 0; i < _instantateCellCount; i++)
        {
            var item = Instantiate(_cellPrefab, _scrollRect.content);

            //上詰めするためにAnchorを設定
            item.anchorMin = new Vector2(0.5f, 1f);
            item.anchorMax = new Vector2(0.5f, 1f);

            //_cellHeight / 2fはPivotの差分
            item.anchoredPosition = new Vector2(0f, -_cellHeight * i + _cellHeight / 2f);
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

                first.anchoredPosition = new Vector2(0f, last.anchoredPosition.y - _cellHeight);
            }
            else
            {
                //下方向へのスクロール
                //一番下の要素を一番上に移動
                _cellList.RemoveLast();
                _cellList.AddFirst(last);

                last.anchoredPosition = new Vector2(0f, first.anchoredPosition.y + _cellHeight);
            }
        }
    }
}
