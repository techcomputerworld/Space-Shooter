using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    //GameObject que instanciaremos en la escena 
    public GameObject shot;
    //posicion y rotacion de donde queremos poner el disparo
    public Transform shotSpawn;
    //delay tiempo de disparo inicial
    public float delay;
    //espera entre llamadas a metodo Fire()
    public float fireRate;

    public AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start () {
        //este metodo lo que hace desde que empieza Start se llamaal metodo Fire() se va a poner esperando el tiempo que hay en el fireRate o tercer parametro
        InvokeRepeating("Fire", delay, fireRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();
    }
}
