using UnityEngine;
using DG.Tweening;

public class TitleMove : MonoBehaviour
{
    [SerializeField] GameObject[] _title;
    [SerializeField] Transform _endPosition;
    [SerializeField]float _moveX;
    float _x;
    void Start()
    {
        for(int i = 0; i < _title.Length; i++)
        {
            _title[i].transform.DOJump(new Vector2(_endPosition.position.x + _x, _endPosition.position.y), 100f, 2, 3f);
            _x += _moveX;
        }
    }
}