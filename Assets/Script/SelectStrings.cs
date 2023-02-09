using UnityEngine;

public class SelectStrings : MonoBehaviour
{
    //選択した文字を格納
    public char[] _select = new char[4];
    //答えの文字列
    string _answer = "しろいろ";

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