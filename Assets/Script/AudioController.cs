using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

[RequireComponent(typeof(AudioSource))]
public class AudioController : SingletonMonoBehaviour<AudioController>
{
    [SerializeField] AudioClip[] _seAudios;
     AudioSource _audio;
    private void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    public void SePlay(SelectAudio selectAudio)
    {
        int index = (int)selectAudio;
        _audio.PlayOneShot(_seAudios[index]);
    }
}

public enum SelectAudio
{
    Failed,
    Success,
    Click,
}