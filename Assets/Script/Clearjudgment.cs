using UnityEngine;

public class Clearjudgment : MonoBehaviour
{
    public static int Stagenumber = 0;
    public static bool StageClear = false;

    public void ClearJudgment (bool clear, int stagenum)
    {
        if (clear)
        {
            StageClear = true;
            Stagenumber = stagenum;
        }
    }
}
