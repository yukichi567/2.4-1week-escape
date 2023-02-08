using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Scene : MonoBehaviour
{
    public static void SceneMove()
    {
        SceneManager.LoadScene("Stage4");
    }
}