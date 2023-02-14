using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChenge : MonoBehaviour
{
    [Header("必ず3つ用意して入れておく 1Main　2Mystery　3Hint")]
    [SerializeField] CinemachineVirtualCamera[] _camera;
    int _priorityNum = 11;
    int _dwonNum = 10;

    /// <summary>
    /// メインカメラへの移動
    /// </summary>
    public void MainCamera()
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        _camera[0].Priority = _priorityNum;
        _camera[1].Priority = _dwonNum;
        _camera[2].Priority = _dwonNum;
    }

    /// <summary>
    /// 謎解きカメラへの移動
    /// </summary>
    public void MysteryCamera()
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        _camera[0].Priority = _dwonNum;
        _camera[1].Priority = _priorityNum;
        _camera[2].Priority = _dwonNum;
    }

    /// <summary>
    /// ヒントカメラへの移動
    /// </summary>
    public void HintCamera()
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        _camera[0].Priority = _dwonNum;
        _camera[1].Priority = _dwonNum;
        _camera[2].Priority = _priorityNum;
    }
}
