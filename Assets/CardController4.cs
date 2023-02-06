using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.EventSystems;

public class CardController4 : MonoBehaviour
{
    GameObject[] _answerPositions;
    [SerializeField] float _settingArea;
    void Start()
    {
        _answerPositions = GameObject.FindGameObjectsWithTag("AnswerPosition");
    }

    void Update()
    {
        for(int i = 0; i < _answerPositions.Length; i++)
        {
            float dis = Vector2.Distance(transform.position, _answerPositions[i].transform.position);
            if(dis < _settingArea)
            {
                transform.position = _answerPositions[i].transform.position;
            }
        }
    }
}