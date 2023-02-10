using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>指定の場所にすべてのピースがはまっているか判定するスクリプト</summary>
public class PiecePlacementCheck : MonoBehaviour
{
    [SerializeField, Header("はめる予定のピース")] private PiecePlacement[] _pieces = new PiecePlacement[3];

    /// <summary>全部のピースが指定の位置にいるかを判定する</summary>
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
            //クリア！
            Debug.Log("クリア");
        }

    }

}
