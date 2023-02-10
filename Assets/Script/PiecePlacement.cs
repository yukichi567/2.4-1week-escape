using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>�s�[�X���ړ������āA�Ή�����ꏊ�ɒu���X�N���v�g</summary>
public class PiecePlacement : MonoBehaviour
{
    [Tooltip("�ŏ��̈ʒu")] private Vector2 _originPos = default;
    [SerializeField, Header("�����̏ꏊ�̃R���C�_�[")] private Collider2D _answerCol = default;
    [SerializeField, Tooltip("�����̃R���C�_�[�ɐG��Ă��邩")] private bool _isCorrectPosition = false;

    /// <summary>���Ƃ��Ƃ̈ʒu</summary>
    public Vector2 OriginPos => _originPos;
    /// <summary>�����̃R���C�_�[</summary>
    public Collider2D AnswerCol => _answerCol;
    /// <summary>�����̏ꏊ�ɐG��Ă��邩</summary>
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
