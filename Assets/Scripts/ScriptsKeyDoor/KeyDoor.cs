using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    public GameObject Sound;

    public Key.KeyType GetKeyType() {
    	return keyType;
    }

    public void OpenDoor() {
    	Instantiate(Sound);
    	gameObject.SetActive(false);
    }
}
