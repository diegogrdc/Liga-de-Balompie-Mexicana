using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer3Nivel : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 180f;

    [SerializeField] Text CountdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        CountdownText.text = currentTime.ToString();  
        if (currentTime <= 0 ){
            currentTime = 0;
            SceneManager.LoadScene("GameOver");
        } 
    }
}
