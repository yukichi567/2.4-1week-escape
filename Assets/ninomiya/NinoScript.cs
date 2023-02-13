using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class NinoScript : MonoBehaviour
{
    // Start is called before the first frame update
    List<string> _strList = new List<string>(); //���������List
    List<string> _anslist = new List<string>() { "Blue", "Red", "Black", "Green", "Yellow" };�@//����
    [SerializeField] Text _strText;�@//���ǂ̓����������Ă��邩
    Clearjudgment _judgment;
    // Start is called before the first frame update
    void Start()
    {
        _judgment = GameObject.FindObjectOfType<Clearjudgment>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_strList.Count == _anslist.Count)�@//������List��5���͂��ꂽ�Ƃ��̐��𔻒�
        {
            if (_strList.SequenceEqual(_anslist))
            {
                Debug.Log("�������܂���");
                AudioController.Instance.SePlay(SelectAudio.Success);
                _judgment.ClearJudgment(true);
            }
            else
            {
                _strList.RemoveRange(0, _anslist.Count);
                AudioController.Instance.SePlay(SelectAudio.Failed);
            }
        }
        _strText.text = string.Join(",", _strList);
    }
    public void Bottun(int key)�@//Bottun�ŌĂԊ֐�(Dictionary
    {
        var dic = new Dictionary<int, string>()
        {
            {1,"Red" },
            {2,"Yellow" },
            {3,"Blue" },
            {4,"Green" },
            {5,"Black" }
        };
        if(_strList.Count < 5)
        {
            _strList.Add(dic[key]);
            AudioController.Instance.SePlay(SelectAudio.Click);
        }
    }
    public void DeliteKey() //Delite�L�[�ŌĂԊ֐�
    {
        if (_strList.Count > 0)
        {
            _strList.RemoveAt(_strList.Count - 1);
        }
    }
}
