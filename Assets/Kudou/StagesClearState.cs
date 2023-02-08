using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StagesClearState : MonoBehaviour
{
    
    [SerializeField, Header("�eStageScene�ɑJ�ڂ���Button��\������Canvas")] Canvas _stageCanvas;
    [SerializeField, Header("�N���A�������ǂ���")] public static bool _isClear;

    /// <summary>�I������Button��ۑ����邽�߂̕ϐ�</summary>
    public static string _selectButton;
    /// <summary>Key:�eStageScene�ɑJ�ڂ���ButtonGameObject�̖��O Value:True��������N���A���Ă���</summary>
    public static Dictionary<string, bool> _stageSelectButtons = new Dictionary<string, bool>();

    private void Awake()
    {
        Debug.Log(_isClear);
        //��ԍŏ��ɍs�������E���̃V�[���ւ̑J�ڂ����ڈȍ~�̎���Dictinary�ɒǉ����Ȃ��悤�ɂ���
        if (_stageSelectButtons.Count == 0)
        {
            //Canvas�̎q�I�u�W�F�N�g�̊eStage�ɑJ�ڂ���Button�I�u�W�F�N�g�̖��O�����Ă���
            //�ŏ��͑S�X�e�[�W�N���A���Ă��Ȃ���ԂȂ̂�false�����Ă���
            for (var i = 0; i < _stageCanvas.transform.childCount; i++)
            {
                _stageSelectButtons.Add(_stageCanvas.transform.GetChild(i).gameObject.name, false);
            }
        }
    }

    private void Start()
    {
        //����null����Ȃ�������
        if (_selectButton != null)
        {
            //�N���A�����Dictinary�ɕۑ�
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

    /// <summary>Button�I�u�W�F�N�g�ɂ��Ă���On Click���\�b�h����Ă΂�܂�</summary>
    /// <param name="go">�����ꂽButton�I�u�W�F�N�g</param>
    public void SelectButton(GameObject go)
    {
        //�I������Button�I�u�W�F�N�g�̖��O��ۑ�
        _selectButton = go.gameObject.name;
        //static�Ȃ̂ŏ�����;
        _isClear = false;
        //�V�[���J��
        SceneManager.LoadScene("Test2");
    }
}
