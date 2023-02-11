using UnityEngine;
using System.Linq;

public class SelectStrings5 : SingletonMonoBehaviour<SelectStrings5>
{
    Clearjudgment _clearJudgement;
    //選択した文字を格納
    char[] _select = Enumerable.Repeat('あ', 4).ToArray();
    //答えの文字列
    string _answer = "しろいろ";

    public char[] Select { get => _select; set => _select = value; }

    private void Awake()
    {
        _clearJudgement = GetComponent<Clearjudgment>();
    }
    //正解かどうかを判定する
    public void Answer()
    {
        if (string.Join("", _select) == _answer)
        {
            _clearJudgement.ClearJudgment(true);
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