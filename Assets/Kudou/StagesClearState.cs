using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class StagesClearState : MonoBehaviour
{
    [SerializeField, Header("Event System")] EventSystem _eventSystem; 
    [SerializeField, Header("各StageSceneに遷移するButtonを表示するCanvas")] Canvas _stageCanvas;
    [SerializeField, Header("クリアしたかどうか")] public static bool _isClear;

    /// <summary>選択したButtonを保存するための変数</summary>
    public static string _selectButton;
    /// <summary>Key:各StageSceneに遷移するButtonGameObjectの名前 Value:Trueだったらクリアしている</summary>
    public static Dictionary<string, bool> _stageSelectButtons = new Dictionary<string, bool>();
    /// <summary>
    /// 
    /// </summary>
    string _buttonGoName;

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
        //もしnullじゃなかったら && クリアだったら
        //この場合また同じステージでクリアできなかったとしても更新されない
        if (_selectButton != null && _isClear)
        {
            //クリア判定をDictinaryに保存・更新
            _stageSelectButtons[_selectButton] = _isClear;
        }
        foreach (var button in _stageSelectButtons)
        {
            if (button.Value == true)
            {
                _buttonGoName = button.Key;
                ClearAction();
            }
        }
    }

    private void Update()
    {
        //EventSystemで押したButtonのゲームオブジェクトを
        if(_eventSystem.currentSelectedGameObject != null)
        {
            SelectButton(_eventSystem.currentSelectedGameObject);
        }
    }
    /// <summary>選択したButtonオブジェクトの名前を保存するための関数</summary>
    /// <param name="go">押されたButtonオブジェクト</param>
    public void SelectButton(GameObject go)
    {
        //選択したButtonオブジェクトの名前を保存
        _selectButton = go.name;
        //staticなので初期化;
        _isClear = false;
        //シーン遷移
        SceneManager.LoadScene("Test2");
    }

    public void ClearAction()
    {
        GameObject.Find(_buttonGoName).transform.GetChild(0).GetComponent<Text>().text = "Clear";
    }
  
}
