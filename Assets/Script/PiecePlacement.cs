using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>ピースを移動させて、対応する場所に置くスクリプト</summary>
public class PiecePlacement : MonoBehaviour
{
    [Tooltip("最初の位置")] private Vector2 _originPos = default;
    [SerializeField, Header("正解の場所のコライダー")] private Collider2D _answerCol = default;
    [SerializeField, Tooltip("正解のコライダーに触れているか")] private bool _isCorrectPosition = false;

    /// <summary>もともとの位置</summary>
    public Vector2 OriginPos => _originPos;
    /// <summary>答えのコライダー</summary>
    public Collider2D AnswerCol => _answerCol;
    /// <summary>正解の場所に触れているか</summary>
    public bool IsCorrectPosition => _isCorrectPosition;

    void Start()
    {
        _originPos = gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision == _answerCol)
        {
            _isCorrectPosition = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision == _answerCol)
        {
            _isCorrectPosition = false;
        }

    }
}
