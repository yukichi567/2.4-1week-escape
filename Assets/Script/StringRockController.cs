using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StringRockController : MonoBehaviour
{
    [SerializeField, Tooltip("文字を変えるオブジェクト")] GameObject _selectButton;
    [SerializeField, Tooltip("答えを格納するスクリプト")] SelectStrings _answerButton;
    //表示させる文字
    string _selectString = "あいきしなろ";
    int i;

    private void Awake()
    {
        _answerButton = FindObjectOfType<SelectStrings>();
    }

    //ダイアルを右回し
    public void UpKeyButton(int number)
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        i++;
       //表示する文字の配列を1つ右へずらす
        char c = _selectString[i % _selectString.Length];
        //選択した文字を配列に格納する
        _answerButton._select[number] = c;
        //子オブジェクトにあるTextコンポーネントを取得
        Text keyText = _selectButton.GetComponentInChildren<Text>();
        keyText.text = c.ToString();
    }

    //ダイアルを左回し
    public void DownKeyButton(int number)
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        i--;
        //iが-1になった時配列の最後からスタートする為のif文
        if(i == -1)
        {
            i = 5;
        }
        //表示する文字の配列を1つ左へずらす
        char c = _selectString[i % _selectString.Length];
        //選択した文字を配列に格納する
        _answerButton._select[number] = c;
        //子オブジェクトにあるTextコンポーネントを取得
        Text　keyText = _selectButton.GetComponentInChildren<Text>();
        keyText.text = c.ToString();
    }
}