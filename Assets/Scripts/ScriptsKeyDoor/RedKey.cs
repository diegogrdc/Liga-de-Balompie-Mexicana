using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKey : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    public Renderer rend;
    private Transform playerTransform;  
    public float offsetY;
    public float offsetX;

    public Key nombre;

    public Key.KeyType GetKeyType() {
    	return keyType;
    }

    // Start is called before the first frame update
    void Start() {
    	rend = GetComponent<Renderer>();
        rend.enabled = false;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offsetX = -7f;
        offsetY = 2.8f; 
        
        
    }

    void Update() {

         Vector3 temp = transform.position;
        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;

        temp.x += offsetX;
        temp.y += offsetY;

        transform.position = temp; 

        if (GameObject.Find("Player") != null) {
            KeyHolder keyHolder = GameObject.Find("Player").GetComponent<KeyHolder>();
            //Debug.Log(keyHolder);
            if(keyHolder.ContainsKey(this.GetKeyType())) {
                rend.enabled = true;
            } else {
                rend.enabled = false;
            }
        }
    	
    }
}
/*
private Transform playerTransform;   
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;

        transform.position = temp; 

    }

*/