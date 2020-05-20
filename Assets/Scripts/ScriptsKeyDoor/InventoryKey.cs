using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryKey : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    public Renderer rend;

    public Key.KeyType GetKeyType() {
    	return keyType;
    }

    // Start is called before the first frame update
    void Start() {
    	rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    void Update() {
    	KeyHolder keyHolder = GameObject.Find("Player").GetComponent<KeyHolder>();
    	Debug.Log(keyHolder);
    	if(keyHolder.ContainsKey(this.GetKeyType())) {
    		rend.enabled = true;
    	} else {
    		rend.enabled = false;
    	}
    }
}
