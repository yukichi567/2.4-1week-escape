using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using Cinemachine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] GameObject _menu;
    [SerializeField] GameObject _menuIcon;
    [SerializeField] CinemachineVirtualCamera _mainCamera;
    public void Menu()
    {
        _menu.SetActive(true);
        _menuIcon.SetActive(false);
    }
    public void Back()
    {
        _menu.SetActive(false);
        _menuIcon.SetActive(true);
    }
    public void Title(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void StageSelect(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void MainCameraBack()
    {
        _mainCamera.Priority = 12;
    }
}