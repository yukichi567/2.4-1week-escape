using UnityEngine;
using UnityEngine.UI;

public class StringRock5 : MonoBehaviour
{
    [SerializeField, Tooltip("文字を変えるオブジェクト")] GameObject _selectButton;
    //表示させる文字
    string _selectString = "あいおかきさしずみむらろ";
    int i;

    //ダイアルを右回し
    public void UpKeyButton(int number)
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        i++;
       //表示する文字の配列を1つ右へずらす
        char c = _selectString[i % _selectString.Length];
        //選択した文字を配列に格納する
        SelectStrings5.Instance.Select[number] = c;
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
            i = _selectString.Length - 1;
        }
        //表示する文字の配列を1つ左へずらす
        char c = _selectString[i % _selectString.Length];
        //選択した文字を配列に格納する
        SelectStrings5.Instance.Select[number] = c;
        //子オブジェクトにあるTextコンポーネントを取得
        Text　keyText = _selectButton.GetComponentInChildren<Text>();
        keyText.text = c.ToString();
    }
}