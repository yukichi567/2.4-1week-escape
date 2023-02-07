using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>�w��̏ꏊ�ɂ��ׂẴs�[�X���͂܂��Ă��邩���肷��X�N���v�g</summary>
public class PiecePlacementCheck : MonoBehaviour
{
    [SerializeField, Header("�͂߂�\��̃s�[�X")] private PiecePlacement[] _pieces = new PiecePlacement[3];

    /// <summary>�S���̃s�[�X���w��̈ʒu�ɂ��邩�𔻒肷��</summary>
    public void ClearCheck()
    {
        var count = 0;

        foreach(var p in _pieces)
        {

            if(p.IsCorrectPosition)
            {
                count++;
            }

        }
        
        if(count == _pieces.Length)
        {
            //�N���A�I
            Debug.Log("�N���A");
        }

    }

}
