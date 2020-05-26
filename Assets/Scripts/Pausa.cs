using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
	void Update( )
    {
        if( Input.GetKeyDown( KeyCode.P ) ){
            if(Time.timeScale == 1)
        	{
            	Time.timeScale = 0;
        	}
        	else
        	{
        	    Time.timeScale = 1;
        	}
        }
    }

    public void Pause (){
	if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
}

}
