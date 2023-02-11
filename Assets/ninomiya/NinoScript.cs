using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class NinoScript : MonoBehaviour
{
    // Start is called before the first frame update
    List<string> _strList = new List<string>(); //答え入れるList
    List<string> _anslist = new List<string>() { "Blue", "Red", "Black", "Green", "Yellow" };　//答え
    [SerializeField] Text _strText;　//今どの答えが入っているか
    Clearjudgment _judgment;
    // Start is called before the first frame update
    void Start()
    {
        _judgment = GameObject.FindObjectOfType<Clearjudgment>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_strList.Count == _anslist.Count)　//答えのListに5個入力されたときの正解判定
        {
            if (_strList.SequenceEqual(_anslist))
            {
                Debug.Log("正解しました");
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
    public void Bottun(int key)　//Bottunで呼ぶ関数(Dictionary
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
    public void DeliteKey() //Deliteキーで呼ぶ関数
    {
        if (_strList.Count > 0)
        {
            _strList.RemoveAt(_strList.Count - 1);
        }
    }
}
