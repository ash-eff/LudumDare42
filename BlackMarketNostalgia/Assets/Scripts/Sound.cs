using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    public AudioSource SFX;
    public AudioSource music;

    public bool isMusicOff;
    public bool isSoundOff;

    private void Update()
    {
        music.mute = isMusicOff;
        SFX.mute = isSoundOff;
    }

    public void TurnOffSoundFX()
    {
        isSoundOff = !isSoundOff;
    }

    public void TurnOffMusic()
    {
        isMusicOff = !isMusicOff;
    }
}
