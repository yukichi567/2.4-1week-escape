using UnityEngine;

public class Clearjudgment : MonoBehaviour
{
    /// <summary> クリアしたステージを保存しておくプロパティ</summary>
    public static int Stagenumber = 0;
    /// <summary>クリアしたか否かを保存しておくプロパティ</summary>
    public static bool StageClear = false;
    /// <summary>クリアした場合にどのような処理をするか定義する関数
    ///第一引数にクリアしたかをboolで指定し、
    ///第二引数にそれが何ステージ目かをintで指定する
    /// </summary>
    public void ClearJudgment (bool clear, int stagenum)
    {
        if (clear) //ステージをクリアしていた場合下記に記述した処理を実行する
        {
            StageClear = true;
            Stagenumber = stagenum;
        }
    }
}
