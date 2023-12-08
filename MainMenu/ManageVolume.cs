using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ManageVolume : MonoBehaviour
{
    [SerializeField]  public AudioMixer audioMixer;
    [SerializeField]  public Slider volSlider;

    void Start(){
        // Sets initial values
        // audioMixer.SetFloat("volume",  0f); 
        // volSlider.value = 10f;

        
    }

    // https://www.youtube.com/watch?v=YOaYQrN1oYQ&ab_channel=Brackeys
    public void setVolume(float volume){
        audioMixer.SetFloat("volume", volume);
        Debug.Log(volume);
    }

}
