using UnityEngine;

public class Clearjudgment : MonoBehaviour
{
    /// <summary> �N���A�����X�e�[�W��ۑ����Ă����v���p�e�B</summary>
    public static int Stagenumber = 0;
    /// <summary>�N���A�������ۂ���ۑ����Ă����v���p�e�B</summary>
    public static bool StageClear = false;
    /// <summary>�N���A�����ꍇ�ɂǂ̂悤�ȏ��������邩��`����֐�
    ///�������ɃN���A��������bool�Ŏw�肵�A
    ///�������ɂ��ꂪ���X�e�[�W�ڂ���int�Ŏw�肷��
    /// </summary>
    public void ClearJudgment (bool clear, int stagenum)
    {
        if (clear) //�X�e�[�W���N���A���Ă����ꍇ���L�ɋL�q�������������s����
        {
            StageClear = true;
            Stagenumber = stagenum;
        }
    }
}
