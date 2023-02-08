using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardController4 : MonoBehaviour
{
    //選択したカードのオブジェクトを格納する
    GameObject _selectButton;
    //選択した答えの場所のオブジェクトを格納する
    GameObject _answerButton;
    EventSystem eventSystem;
    GameObject[] _selectObjects = new GameObject[5];
    Dictionary<int, Vector2> _dic = new Dictionary<int, Vector2>();
    //回答の数列を格納する為の配列
    int[] _selectNumbers = new int[5];
    //選択したカードに設定されている番号
    int _selectNumber;
    bool _onSelect;
    string _answer = "31254";


    /// <summary>
    /// カードを選択して選択したカードのオブジェクト情報と設定された数値を変数に保管して今選んでいるかのboolを変更する
    /// </summary>
    /// <param name="number"></param>
    public void SelectButton(int number)//変数numberは選択したカードに設定されている数字(配列に格納して答えと照らし合わせる)
    {
        if (!_onSelect)
        {
            AudioController.Instance.SePlay(SelectAudio.Click);
            //選択したカードの番号を変数に格納
            _selectNumber = number;
            //イベントシステムでボタンを押したオブジェクト情報を取得
            eventSystem = EventSystem.current;
            _selectButton = eventSystem.currentSelectedGameObject;
            //リセットするためにボタンを押したオブジェクト情報を配列に格納この時同じ順番で戻したいからインデックスも指定して格納する
            _selectObjects[number - 1] = _selectButton;
            //選択したカードのインデックス情報と初期位置をDictionary型で格納する
            _dic.Add(number - 1, _selectButton.transform.position);
            //今クリックしているかのboolを切り替える
            _onSelect = !_onSelect;
        }
    }
    /// <summary>
    /// 選択したカードを設置する場所を選択する、その際配列の指定の要素に選択した数字を格納する
    /// </summary>
    /// <param name="number"></param>
    public void AnswerButton(int number)//変数numberは回答になる配列のどの要素に選択したカードの数値を格納するかを決める
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        eventSystem = EventSystem.current;
        if (_onSelect)
        {
            //配列のボタンに設定さえれている要素に選択したカードの数字を格納
            _selectNumbers[number] = _selectNumber;
            _onSelect = !_onSelect;
            //イベントシステムでアンサーポジションのオブジェクト情報を取得
            _answerButton = eventSystem.currentSelectedGameObject;
            //選択したカードの場所をアンサーポジションの場所に変換
            _selectButton.transform.position = _answerButton.transform.position;
        }
    }

    /// <summary>
    /// 格納された配列が答えの文字列と合っているかを判定
    /// </summary>
    public void Answer()
    {
        if(string.Join("", _selectNumbers) == _answer)
        {
            Debug.Log("true");
            AudioController.Instance.SePlay(SelectAudio.Success);
        }
        else
        {
            Debug.Log("false");
            AudioController.Instance.SePlay(SelectAudio.Failed);
            //答えが間違っていたらSelectCardを元の場所に戻す
            foreach (var obj in _dic)
            {
                _selectObjects[obj.Key].transform.position = _dic[obj.Key];
            }
            _dic.Clear();
        }
    }
}