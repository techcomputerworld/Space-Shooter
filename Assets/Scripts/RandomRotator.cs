using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble;

    private Rigidbody rig;
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {
        //crear el vector de esta forma se puede crear de otra forma 
        /* Create the vector form or create vector other form */
        //Vector3 angularVelocity = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
        //para que asignar una variable si podemos directamente utilizar la propiedad directamente
        /* */
        //Vector3 angularVelocity = Random.insideUnitSphere;
        //de esta forma tan sencilla quitamos mucho codigo.
        rig.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	
}
