using UnityEngine;
using DG.Tweening;

public class ClearMove : MonoBehaviour
{
    [SerializeField]Transform _endScale;
    [SerializeField] GameObject _buttons;
    [SerializeField] GameObject _starEffect;
    Transform _targetObject;
    void Start()
    {
        _targetObject = GetComponent<Transform>();
        _targetObject.DOScale(_endScale.localScale, 1f).OnComplete(EndMove);
    }

    void EndMove()
    {
        _buttons.SetActive(true);
        Instantiate(_starEffect);
    }
}