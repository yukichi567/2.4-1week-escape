using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    List<string> _strList = new List<string>();
    List<string> _ansList = new List<string>() { "3", "2", "2", "2" };
    [SerializeField] Text _passText;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        _passText.text = string.Join(" ", _strList);
    }
    public void Bottun(string key)
    {
        if (_strList.Count < 4)
        {
            _strList.Add(key);
            Debug.Log(key);
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
            }
            else
            {
                _strList.RemoveRange(0, _ansList.Count);
                Debug.Log("false");
            }
        }
    }
    public void DeleteClick()
    {
        _strList.RemoveAt(_strList.Count - 1);
        Debug.Log("derete");
    }
}