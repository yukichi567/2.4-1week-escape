using UnityEngine;

public class SelectStrings5 : SingletonMonoBehaviour<SelectStrings5>
{
    //選択した文字を格納
    char[] _select = new char[4];
    //答えの文字列
    string _answer = "しろいろ";

    public char[] Select { get => _select; set => _select = value; }
    //正解かどうかを判定する
    public void Answer()
    {
        if (string.Join("", _select) == _answer)
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