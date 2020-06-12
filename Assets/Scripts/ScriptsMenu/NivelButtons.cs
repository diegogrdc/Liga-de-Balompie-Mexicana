using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelButtons : MonoBehaviour
{
     public void Nivel1(){
            SceneManager.LoadScene("LaberintoConJugador");
        }

    public void Nivel2(){
            SceneManager.LoadScene("Nivel2");
        }
    public void Nivel3(){
            SceneManager.LoadScene("Nivel3");
        }

    public GameObject SeleccionarNivelUI;
	public GameObject MenuUI;

    public void Regresar(){
    	SeleccionarNivelUI.SetActive(false);
    	MenuUI.SetActive(true);
    }

}
