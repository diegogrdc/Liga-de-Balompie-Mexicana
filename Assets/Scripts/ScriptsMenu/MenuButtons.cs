using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void PlayButton(){
            SceneManager.LoadScene("LaberintoConJugador");
        }

    public void QuitGame(){
        Application.Quit();
    }

    public GameObject SeleccionarNivelUI;
	public GameObject MenuUI;

    public void Nivel(){
    	SeleccionarNivelUI.SetActive(true);
    	MenuUI.SetActive(false);
    }

    public GameObject AjustesUI;

    public void Ajustes(){
    	AjustesUI.SetActive(true);
    	MenuUI.SetActive(false);
    }

}
