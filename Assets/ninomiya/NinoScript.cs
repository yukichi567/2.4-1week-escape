using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class NinoScript : MonoBehaviour
{
    // Start is called before the first frame update
    List<string> _strList = new List<string>();
    List<string> _anslist = new List<string>() { "Blue", "Red", "Black", "Green", "Yellow" };
    [SerializeField] Text _strText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_strList.Count == _anslist.Count)
        {
            if (_strList.SequenceEqual(_anslist))
            {
                Debug.Log("³‰ð‚µ‚Ü‚µ‚½");
            }
            else
            {
                _strList.RemoveRange(0, _anslist.Count);
            }
        }
        if (_strList.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                _strList.RemoveAt(_strList.Count - 1);
            }
        }

        _strText.text = string.Join(",", _strList);
    }
    public void Bottun(int key)
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
        }
    }
}
