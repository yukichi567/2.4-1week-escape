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

    public void SePlay()
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
    }
    //タイトルシーンへ移動
    public void Title(string SceneName)
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        SceneManager.LoadScene(SceneName);
    }

    //ステージ選択シーンへ移動
    public void StageSelect(string SceneName)
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        SceneManager.LoadScene(SceneName);
    }

    //ヒント画面を表示
    public void Hint()
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        _menuWindow.SetActive(false);
        _hintWindow.SetActive(true);
    }

    //答え画面を表示
    public void Answer()
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        _menuWindow.SetActive(false);
        _answerWindow.SetActive(true);
    }

    //ヒント画面を閉じる
    public void HintBack()
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        _hintWindow.SetActive(false);
        _menuWindow.SetActive(true);
    }

    //答え画面を閉じる
    public void AnswerBack()
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        _answerWindow.SetActive(false);
        _menuWindow.SetActive(true);
    }
}