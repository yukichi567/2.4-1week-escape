using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenSquare : MonoBehaviour
{
    [SerializeField] string _changeScene;
    public void ScenChange()
    {
        AudioController.Instance.SePlay(SelectAudio.Click);
        SceneManager.LoadScene(_changeScene);
    }
}
