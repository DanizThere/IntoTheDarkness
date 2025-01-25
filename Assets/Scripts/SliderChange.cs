using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderChange : MonoBehaviour
{
    [SerializeField] private AudioMixer music;
    
    public void SetLevel(float sliderValue)
    {
        music.SetFloat("Master", Mathf.Log10 (sliderValue)  * 20);
    }
}
