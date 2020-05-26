using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoSonidos : MonoBehaviour
{
	public float TiempodeVida;
    // Start is called before the first frame update
    void Start()
    {
    	Destroy(gameObject,TiempodeVida);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
