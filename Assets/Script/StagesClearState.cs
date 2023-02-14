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
    //[SerializeField, Header("�N���A�������ǂ���")] public static bool _isClear;

    /// <summary>�I������Button��ۑ����邽�߂̕ϐ�</summary>
    public static string _selectButton;
    /// <summary>Key:�eStageScene�ɑJ�ڂ���ButtonGameObject�̖��O Value:True��������N���A���Ă���</summary>
    public static Dictionary<string, bool> _stageSelectButtons = new Dictionary<string, bool>();

    private void Awake()
    {
        //��ԍŏ��ɍs�������E���̃V�[���ւ̑J�ڂ����ڈȍ~�̏ꍇ��Dictinary�ɒǉ����Ȃ��悤�ɂ���
        if (_stageSelectButtons.Count == 0)
        {
            //Canvas�̎q�I�u�W�F�N�g�̊eStage�ɑJ�ڂ���Button�I�u�W�F�N�g�̖��O�����Ă���
            //�ŏ��͑S�X�e�[�W�N���A���Ă��Ȃ���ԂȂ̂�false�����Ă���
            for (var i = 0; i < _stageCanvas.transform.childCount; i++)
            {
                _stageSelectButtons.Add(_stageCanvas.transform.GetChild(i).gameObject.name, false);
            }
        }
        //�ŏ���Clear�\�����Ȃ�
        foreach (var button in _stageSelectButtons)
        {
            ClearImageSetActive(false, button.Key);
        }
    }

    private void Start()
    {
        //����null����Ȃ������� && �N���A��������
        //���̏ꍇ�����X�e�[�W�ŃN���A�ł��Ȃ������Ƃ��Ă��X�V����Ȃ�
        if (_selectButton != null && Clearjudgment.StageClear)
        {
            //�N���A�����Dictinary�ɕۑ��E�X�V
            _stageSelectButtons[_selectButton] = Clearjudgment.StageClear;
        }
        foreach (var button in _stageSelectButtons)
        {
            //�����N���A���Ă�����
            if (button.Value == true)
            {
                //�N���AImage��\������
                ClearImageSetActive(true, button.Key);
            }
        }
    }

    private void Update()
    {
        //EventSystem�ŉ�����Button�̃Q�[���I�u�W�F�N�g���擾
        if(_eventSystem.currentSelectedGameObject != null)
        {
            SelectButton(_eventSystem.currentSelectedGameObject);
        }
    }
    /// <summary>�I������Button�I�u�W�F�N�g�̖��O��ۑ����邽�߂̊֐�</summary>
    /// <param name="go">�����ꂽButton�I�u�W�F�N�g</param>
    public void SelectButton(GameObject go)
    {
        //�I������Button�I�u�W�F�N�g�̖��O��static�ϐ��ɕۑ�
        _selectButton = go.name;
        //static�Ȃ̂ŃN���A����̕ϐ���������;
        Clearjudgment.StageClear = false;
        //�V�[���J��
        //SceneManager.LoadScene("Test2");
    }

    /// <summary>�eButton�ɂ��Ă���ClearImage��\���E��\������֐�</summary>
    /// <param name="trueOrfalse">true�̎��͕\������</param>
    /// <param name="buttonName">Stage��I������Button�I�u�W�F�N�g�̖��O</param>
    public void ClearImageSetActive(bool trueOrfalse, string buttonName)
    {
        GameObject.Find(buttonName).transform.GetChild(1).gameObject.SetActive(trueOrfalse);
    }
  
}
