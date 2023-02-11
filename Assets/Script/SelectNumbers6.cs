using UnityEngine;
using System.Linq;

public class SelectNumbers6 : SingletonMonoBehaviour<SelectNumbers6>
{
    Clearjudgment _clearJudgement;
    //�I�������������i�[
    string[] _select = new string[4];
    //�����̕�����
    string[] _answer = { "VII", "II", "IV", "III"};

    public string[] Select { get => _select; set => _select = value; }
    private void Awake()
    {
        _clearJudgement = GetComponent<Clearjudgment>();
    }
    //�������𔻒肷��
    public void Answer()
    {
        if (string.Join("", _select) == string.Join("", _answer))
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