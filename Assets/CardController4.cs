using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.EventSystems;

public class CardController4 : MonoBehaviour
{
    [SerializeField]LayerMask _cardLayer;
    Vector2 _basePosition;
    bool _onDrag;
    void Start()
    {
        _basePosition = transform.position;
    }

    void Update()
    {
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //var hit = Physics2D.Raycast(ray.origin, ray.direction, 100);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //カメラの位置からマウスの位置までRayを飛ばす
        //RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        Debug.DrawLine(ray.origin, ray.direction, Color.red);
        Debug.DrawRay(ray.origin, ray.direction);
        if(Physics.Raycast(ray, out RaycastHit hit, _cardLayer))
        {
            Debug.Log("当たった");
            if(Input.GetButtonDown("Fire1"))
            {
                _onDrag = !_onDrag;
            }
        }
        if(_onDrag)
        {
            transform.position = Input.mousePosition;
        }
    }
}