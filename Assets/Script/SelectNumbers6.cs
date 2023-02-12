using UnityEngine;
using System.Linq;

public class SelectNumbers6 : SingletonMonoBehaviour<SelectNumbers6>
{
    Clearjudgment _clearJudgement;
    //ëIëÇµÇΩï∂éöÇäiî[
    char[] _select = Enumerable.Repeat('0', 4).ToArray();
    //ìöÇ¶ÇÃï∂éöóÒ
    string _answer = "2085";

    public char[] Select { get => _select; set => _select = value; }
    private void Awake()
    {
        _clearJudgement = GetComponent<Clearjudgment>();
    }
    //ê≥âÇ©ÇîªíËÇ∑ÇÈ
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