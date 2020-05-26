using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public GameObject Sonido;
	
	[SerializeField] private KeyType keyType;
	
    public enum KeyType {
    	Red,
    	Green,
    	Blue

    }

    public KeyType GetKeyType() {
    	return keyType;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         Instantiate(Sonido);
    }
}
