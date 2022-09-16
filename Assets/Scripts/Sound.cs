using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Text volumeUI;
    public void SoundVolume(float value)
    {
        AudioListener.volume = value;
        volumeUI.text = "% "+ (int)(value*100);
    }
}
