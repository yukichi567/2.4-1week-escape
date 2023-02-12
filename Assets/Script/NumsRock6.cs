using UnityEngine;
using UnityEngine.UI;

public class NumsRock6 : MonoBehaviour
{
    [SerializeField, Tooltip("������ς���I�u�W�F�N�g")] GameObject _selectButton;
    //�\�������镶��
   �@string _selectString = "0123456789";
    int i;

    //�_�C�A�������
    public void UpKeyButton(int number)
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        i++;
        //�\�����镶���̔z���1��ւ��炷
        char s = _selectString[i % _selectString.Length];
        //�I������������z��Ɋi�[����
        SelectNumbers6.Instance.Select[number] = s;
        //�q�I�u�W�F�N�g�ɂ���Text�R���|�[�l���g���擾
        Text keyText = _selectButton.GetComponentInChildren<Text>();
        keyText.text = s.ToString();
    }

    //�_�C�A��������
    public void DownKeyButton(int number)
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        i--;
        //i��-1�ɂȂ������z��̍Ōォ��X�^�[�g����ׂ�if��
        if (i == -1)
        {
            i = _selectString.Length - 1;
        }
        //�\�����镶���̔z���1���ւ��炷
        char s = _selectString[i % _selectString.Length];
        //�I������������z��Ɋi�[����
        SelectNumbers6.Instance.Select[number] = s;
        //�q�I�u�W�F�N�g�ɂ���Text�R���|�[�l���g���擾
        Text keyText = _selectButton.GetComponentInChildren<Text>();
        keyText.text = s.ToString();
    }
}