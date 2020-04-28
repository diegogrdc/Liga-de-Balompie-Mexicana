using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update() {
        if (Input.GetMouseButton(0))
            SceneManager.LoadScene("LaberintoConJugador");
    }

}
