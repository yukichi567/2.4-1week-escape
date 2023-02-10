using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class MenuButton : MonoBehaviour
{
    [SerializeField, Tooltip("メニューウィンドウ")] GameObject _menuWindow;
    [SerializeField, Tooltip("メニューアイコン")] GameObject _menuIcon;
    [SerializeField, Tooltip("ヒントウィンドウ")] GameObject _hintWindow;
    [SerializeField, Tooltip("答えウィンドウ")] GameObject _answerWindow;
    [SerializeField] CinemachineVirtualCamera _mainCamera;

    //メニューウィンドウを表示　メニューアイコンを非表示
    public void Menu()
    {
        _menuWindow.SetActive(true);
        _menuIcon.SetActive(false);
    }

    //メニューウィンドウを非表示　メニューアイコンを表示
    public void Back()
    {
        _menuWindow.SetActive(false);
        _menuIcon.SetActive(true);
    }

    //タイトルシーンへ移動
    public void Title(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    //ステージ選択シーンへ移動
    public void StageSelect(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    //ヒント画面を表示
    public void Hint()
    {
        _menuWindow.SetActive(false);
        _hintWindow.SetActive(true);
    }

    //答え画面を表示
    public void Answer()
    {
        _menuWindow.SetActive(false);
        _answerWindow.SetActive(true);
    }

    //ヒント画面を閉じる
    public void HintBack()
    {
        _hintWindow.SetActive(false);
        _menuWindow.SetActive(true);
    }

    //答え画面を閉じる
    public void AnswerBack()
    {
        _answerWindow.SetActive(false);
        _menuWindow.SetActive(true);
    }
}