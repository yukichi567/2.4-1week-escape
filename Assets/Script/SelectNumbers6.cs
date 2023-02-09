using UnityEngine;
using System.Linq;

public class SelectNumbers6 : SingletonMonoBehaviour<SelectNumbers6>
{
    //選択した文字を格納
    string[] _select = new string[4];
    //答えの文字列
    string[] _answer = { "VII", "II", "IV", "III"};

    public string[] Select { get => _select; set => _select = value; }
    //正解かを判定する
    public void Answer()
    {
        if (string.Join("", _select) == string.Join("", _answer))
        {
            Debug.Log("true");
            AudioController.Instance.SePlay(SelectAudio.Success);
        }
        else
        {
            Debug.Log("false");
            AudioController.Instance.SePlay(SelectAudio.Failed);
        }
    }
}