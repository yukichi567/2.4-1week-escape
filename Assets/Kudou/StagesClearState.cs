using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class StagesClearState : MonoBehaviour
{
    [SerializeField, Header("Event System")] EventSystem _eventSystem; 
    [SerializeField, Header("�eStageScene�ɑJ�ڂ���Button��\������Canvas")] Canvas _stageCanvas;
    [SerializeField, Header("�N���A�������ǂ���")] public static bool _isClear;

    /// <summary>�I������Button��ۑ����邽�߂̕ϐ�</summary>
    public static string _selectButton;
    /// <summary>Key:�eStageScene�ɑJ�ڂ���ButtonGameObject�̖��O Value:True��������N���A���Ă���</summary>
    public static Dictionary<string, bool> _stageSelectButtons = new Dictionary<string, bool>();
    /// <summary>
    /// 
    /// </summary>
    string _buttonGoName;

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
        //����null����Ȃ������� && �N���A��������
        //���̏ꍇ�܂������X�e�[�W�ŃN���A�ł��Ȃ������Ƃ��Ă��X�V����Ȃ�
        if (_selectButton != null && _isClear)
        {
            //�N���A�����Dictinary�ɕۑ��E�X�V
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
        //EventSystem�ŉ�����Button�̃Q�[���I�u�W�F�N�g��
        if(_eventSystem.currentSelectedGameObject != null)
        {
            SelectButton(_eventSystem.currentSelectedGameObject);
        }
    }
    /// <summary>�I������Button�I�u�W�F�N�g�̖��O��ۑ����邽�߂̊֐�</summary>
    /// <param name="go">�����ꂽButton�I�u�W�F�N�g</param>
    public void SelectButton(GameObject go)
    {
        //�I������Button�I�u�W�F�N�g�̖��O��ۑ�
        _selectButton = go.name;
        //static�Ȃ̂ŏ�����;
        _isClear = false;
        //�V�[���J��
        SceneManager.LoadScene("Test2");
    }

    public void ClearAction()
    {
        GameObject.Find(_buttonGoName).transform.GetChild(0).GetComponent<Text>().text = "Clear";
    }
  
}
