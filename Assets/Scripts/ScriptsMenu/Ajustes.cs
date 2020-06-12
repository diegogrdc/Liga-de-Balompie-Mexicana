using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ajustes : MonoBehaviour
{
	

	public AudioMixer audioMixer;
    public void SetVolume (float volume){
    	audioMixer.SetFloat("volume",volume);
    }

    public GameObject AjustesUI;
	public GameObject MenuUI;
    public void Regresar(){
    	AjustesUI.SetActive(false);
    	MenuUI.SetActive(true);
    }

    public void SetFullScreen (bool isFullScreen){
    	Screen.fullScreen = isFullScreen;
    }
}
