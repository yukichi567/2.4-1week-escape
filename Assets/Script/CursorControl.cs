using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>�v���C���[�̃J�[�\������Ɋۓ������Ă�</summary>
public class CursorControl : MonoBehaviour
{
    [SerializeField, Tooltip("�s�[�X�I�����Ă邩")] private bool _isPieceSelected = false;
    [Tooltip("�^��ł�s�[�X")] private GameObject _piece = default;
    [Tooltip("�^��ł�s�[�X�ɂ��Ă�X�N���v�g")] private PiecePlacement _piecePlacement = default;
    [SerializeField, Header("�N���A�`�F�b�N�̃X�N���v�g")] private PiecePlacementCheck _piecePlacementCheck = default;

    void Update()
    {
        var mousePos = Input.mousePosition;
        var worldPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));
        var convWorldPos = new Vector3(worldPos.x, worldPos.y, 1);
        transform.position = convWorldPos;

        if(Input.GetMouseButton(0))
        {

            //�s�[�X�I��ł���J�[�\���ɍ��킹�Ĉړ�������
            if(_isPieceSelected)
            {
                _piece.transform.position = gameObject.transform.position;
            }

        }
        else if(Input.GetMouseButtonUp(0))
        {

            if(_isPieceSelected)
            {

                //�����̏ꏊ�ɂ����炻���ɒu��
                if (_piecePlacement.IsCorrectPosition)
                {
                    _piece.transform.position = _piecePlacement.AnswerCol.transform.position;
                    _piecePlacementCheck.ClearCheck();
                }
                //���Ȃ������猳�̈ʒu�ɖ߂�
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
