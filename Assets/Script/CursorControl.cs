using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>プレイヤーのカーソル代わりに丸動かしてる</summary>
public class CursorControl : MonoBehaviour
{
    [SerializeField, Tooltip("ピース選択してるか")] private bool _isPieceSelected = false;
    [Tooltip("運んでるピース")] private GameObject _piece = default;
    [Tooltip("運んでるピースについてるスクリプト")] private PiecePlacement _piecePlacement = default;
    [SerializeField, Header("クリアチェックのスクリプト")] private PiecePlacementCheck _piecePlacementCheck = default;

    void Update()
    {
        var mousePos = Input.mousePosition;
        var worldPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));
        var convWorldPos = new Vector3(worldPos.x, worldPos.y, 1);
        transform.position = convWorldPos;

        if(Input.GetMouseButton(0))
        {

            //ピース選んでたらカーソルに合わせて移動させる
            if(_isPieceSelected)
            {
                _piece.transform.position = gameObject.transform.position;
            }

        }
        else if(Input.GetMouseButtonUp(0))
        {

            if(_isPieceSelected)
            {

                //正解の場所にいたらそこに置く
                if (_piecePlacement.IsCorrectPosition)
                {
                    _piece.transform.position = _piecePlacement.AnswerCol.transform.position;
                    _piecePlacementCheck.ClearCheck();
                }
                //いなかったら元の位置に戻す
                else
                {
                    _piece.transform.position = _piecePlacement.OriginPos;
                }

            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Piece" &&!_isPieceSelected)
        {
            _isPieceSelected = true;
            _piece = collision.gameObject;
            _piecePlacement = _piece.GetComponent<PiecePlacement>();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject == _piece && _isPieceSelected)
        {
            _isPieceSelected = false;
            _piece = default;
            _piecePlacement = default;
        }

    }
}
