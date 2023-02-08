using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StagesClearState : MonoBehaviour
{
    
    [SerializeField, Header("各StageSceneに遷移するButtonを表示するCanvas")] Canvas _stageCanvas;
    [SerializeField, Header("クリアしたかどうか")] public static bool _isClear;

    /// <summary>選択したButtonを保存するための変数</summary>
    public static string _selectButton;
    /// <summary>Key:各StageSceneに遷移するButtonGameObjectの名前 Value:Trueだったらクリアしている</summary>
    public static Dictionary<string, bool> _stageSelectButtons = new Dictionary<string, bool>();

    private void Awake()
    {
        Debug.Log(_isClear);
        //一番最初に行う処理・このシーンへの遷移が二回目以降の時はDictinaryに追加しないようにする
        if (_stageSelectButtons.Count == 0)
        {
            //Canvasの子オブジェクトの各Stageに遷移するButtonオブジェクトの名前を入れておく
            //最初は全ステージクリアしていない状態なのでfalseを入れておく
            for (var i = 0; i < _stageCanvas.transform.childCount; i++)
            {
                _stageSelectButtons.Add(_stageCanvas.transform.GetChild(i).gameObject.name, false);
            }
        }
    }

    private void Start()
    {
        //もしnullじゃなかったら
        if (_selectButton != null)
        {
            //クリア判定をDictinaryに保存
            _stageSelectButtons[_selectButton] = _isClear;
        }
        foreach (var button in _stageSelectButtons)
        {
            if (button.Value == true)
            {
                string goName = button.Key;
                GameObject.Find(goName).transform.GetChild(0).GetComponent<Text>().text = "Clear";
            }
        }
    }

    /// <summary>ButtonオブジェクトについているOn Clickメソッドから呼ばれます</summary>
    /// <param name="go">押されたButtonオブジェクト</param>
    public void SelectButton(GameObject go)
    {
        //選択したButtonオブジェクトの名前を保存
        _selectButton = go.gameObject.name;
        //staticなので初期化;
        _isClear = false;
        //シーン遷移
        SceneManager.LoadScene("Test2");
    }
}
