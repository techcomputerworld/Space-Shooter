using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    //esta variable tipo GameObject pondre la explosión 
    public GameObject explosion;
    public GameObject playerExplosion;

    private void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log(other.name);
        //if (other.tag == "Boundary") return;
        if (other.CompareTag("Boundary")) return;
        Debug.Log(other.name);
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
