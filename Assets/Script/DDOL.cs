using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class DDOL : MonoBehaviour
{
    void Start()
    {
        if(FindObjectsOfType<DDOL>().Length > 1)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }
}