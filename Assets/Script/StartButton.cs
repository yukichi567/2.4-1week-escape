using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    //変更前
    [SerializeField] GameObject _default;
    //変更後
    [SerializeField] GameObject _destination;


    // Update is called once per frame


    public void StartB()
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        _default.SetActive(false);
        _destination.SetActive(true);
    }
}
