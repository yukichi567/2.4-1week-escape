using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    Image _fadeImage;
    void Start()
    {
        _fadeImage = GetComponent<Image>();
        _fadeImage.DOFade(0, 1f).OnComplete(() => _fadeImage.gameObject.SetActive(false));
    }
}