using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class MenuButton : MonoBehaviour
{
    [SerializeField, Tooltip("メニューウィンドウ")] GameObject _menu;
    [SerializeField, Tooltip("メニューアイコン")] GameObject _menuIcon;
    [SerializeField] CinemachineVirtualCamera _mainCamera;

    //メニューウィンドウを表示　メニューアイコンを非表示
    public void Menu()
    {
        _menu.SetActive(true);
        _menuIcon.SetActive(false);
    }

    //メニューウィンドウを非表示　メニューアイコンを表示
    public void Back()
    {
        _menu.SetActive(false);
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
    public void MainCameraBack()
    {
        _mainCamera.Priority = 12;
    }
}