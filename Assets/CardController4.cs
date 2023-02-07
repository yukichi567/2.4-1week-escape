using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.EventSystems;

public class CardController4 : MonoBehaviour
{
    [SerializeField] Color _onSelectColor;
    [SerializeField] Color _notSelectColor;
    GameObject _selectButton;
    GameObject _answerButton;
    EventSystem eventSystem;
    Color _myColor;
    public bool _onSelect;
  
    public void SelectButton()
    {
        eventSystem = EventSystem.current;
        _selectButton = eventSystem.currentSelectedGameObject;
        _onSelect = !_onSelect;
    }
    public void AnswerButton()
    {
        eventSystem = EventSystem.current;
        if (_onSelect)
        {
            _onSelect = !_onSelect;
            _answerButton = eventSystem.currentSelectedGameObject;
            _selectButton.transform.position = _answerButton.transform.position;
        }
    }
}