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
    //[SerializeField, Header("クリアしたかどうか")] public static bool _isClear;

    /// <summary>選択したButtonを保存するための変数</summary>
    public static string _selectButton;
    /// <summary>Key:各StageSceneに遷移するButtonGameObjectの名前 Value:Trueだったらクリアしている</summary>
    public static Dictionary<string, bool> _stageSelectButtons = new Dictionary<string, bool>();

    private void Awake()
    {
        //一番最初に行う処理・このシーンへの遷移が二回目以降の場合はDictinaryに追加しないようにする
        if (_stageSelectButtons.Count == 0)
        {
            //Canvasの子オブジェクトの各Stageに遷移するButtonオブジェクトの名前を入れておく
            //最初は全ステージクリアしていない状態なのでfalseを入れておく
            for (var i = 0; i < _stageCanvas.transform.childCount; i++)
            {
                _stageSelectButtons.Add(_stageCanvas.transform.GetChild(i).gameObject.name, false);
            }
        }
        //最初はClear表示しない
        foreach (var button in _stageSelectButtons)
        {
            ClearImageSetActive(false, button.Key);
        }
    }

    private void Start()
    {
        //もしnullじゃなかったら && クリアだったら
        //この場合同じステージでクリアできなかったとしても更新されない
        if (_selectButton != null && Clearjudgment.StageClear)
        {
            //クリア判定をDictinaryに保存・更新
            _stageSelectButtons[_selectButton] = Clearjudgment.StageClear;
        }
        foreach (var button in _stageSelectButtons)
        {
            //もしクリアしていたら
            if (button.Value == true)
            {
                //クリアImageを表示する
                ClearImageSetActive(true, button.Key);
            }
        }
    }

    private void Update()
    {
        //EventSystemで押したButtonのゲームオブジェクトを取得
        if(_eventSystem.currentSelectedGameObject != null)
        {
            SelectButton(_eventSystem.currentSelectedGameObject);
        }
    }
    /// <summary>選択したButtonオブジェクトの名前を保存するための関数</summary>
    /// <param name="go">押されたButtonオブジェクト</param>
    public void SelectButton(GameObject go)
    {
        //選択したButtonオブジェクトの名前をstatic変数に保存
        _selectButton = go.name;
        //staticなのでクリア判定の変数を初期化;
        Clearjudgment.StageClear = false;
        //シーン遷移
        //SceneManager.LoadScene("Test2");
    }

    /// <summary>各ButtonについているClearImageを表示・非表示する関数</summary>
    /// <param name="trueOrfalse">trueの時は表示する</param>
    /// <param name="buttonName">Stageを選択するButtonオブジェクトの名前</param>
    public void ClearImageSetActive(bool trueOrfalse, string buttonName)
    {
        GameObject.Find(buttonName).transform.GetChild(1).gameObject.SetActive(trueOrfalse);
    }
  
}
