using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;

    private Rigidbody rig;
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    
    void Start () {
        //eje x transform.right, eje y transform.up, eje z transform.forward 
        // forward tendremos la velocidad a 1 esta normalizado
        rig.velocity = transform.forward * speed;
	}
	
	
}
