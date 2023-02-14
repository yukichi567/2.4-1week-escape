using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    List<string> _strList = new List<string>();
    List<string> _ansList = new List<string>() { "4", "2", "2", "2" };
    [SerializeField] Text _passText;
    Clearjudgment _clearJudgement;
    // Start is called before the first frame update
    private void Awake()
    {
        _clearJudgement = FindObjectOfType<Clearjudgment>();
    }
    // Update is called once per frame
    void Update()
    {
        _passText.text = string.Join("", _strList);
    }
    public void Bottun(string key)
    {
        if (_strList.Count < 4)
        {
            _strList.Add(key);
            Debug.Log(key);
            AudioController.Instance.SePlay(SelectAudio.Click);
        }
    }
    public void OKClick()
    {
        if (_strList.Count == _ansList.Count)
        {
            if (_strList.SequenceEqual(_ansList))
            {
                _strList.RemoveRange(0, _ansList.Count);
                Debug.Log("Clear");
                AudioController.Instance.SePlay(SelectAudio.Success);
                _clearJudgement.ClearJudgment(true);
            }
            else
            {
                _strList.RemoveRange(0, _ansList.Count);
                Debug.Log("false");
                AudioController.Instance.SePlay(SelectAudio.Failed);
            }
        }
    }
    public void DeleteClick()
    {
        _strList.RemoveAt(_strList.Count - 1);
        Debug.Log("derete");
        AudioController.Instance.SePlay(SelectAudio.Click);
    }
}