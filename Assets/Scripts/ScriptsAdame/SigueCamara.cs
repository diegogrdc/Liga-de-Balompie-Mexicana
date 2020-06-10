using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SigueCamara : MonoBehaviour
{
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").Transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
