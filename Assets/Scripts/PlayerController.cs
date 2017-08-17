using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {

    [Header("Movement")]
    public float speed;
    //tilt es giro
    public float tilt;
    public Boundary boundary;

    private Rigidbody rig;
    [Header("Shooting")]
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    private AudioSource audioSource;
    // Use this for initialization
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    
    private void Start()
    {
        //actualizaremos los limites dependiendo de la resolucion de pantalla. 
        UpdateBoundary();
    }
    
    void UpdateBoundary()
    {
        Vector2 half = Utils.GetHalfDimensionsInWorldUnits();

        //xMin -6 
        //xMax 6 
        //zMin -4
        //zMax 8 

        boundary.xMin = -half.x + 0.7f;
        boundary.xMax = half.x - 0.7f;
        boundary.zMin = -half.y + 6.8f;
        boundary.zMax = half.y - 2f;
        Debug.Log(half);

    }
    
    // Update is called once per frame
    void Update () {
		if (CrossPlatformInputManager.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //si cambiamos shotSpawn.rotation por Quaternion.identity lo pondremos a 0 la rotacion 
            Instantiate(shot, shotSpawn.position, Quaternion.identity);
            audioSource.Play();
        }
    
	}
    private void FixedUpdate()
    {
        //Para mover en horizontal  la nave, el boton negativo izquierda y positivo derecha. valores entre -1 y 1, 0 si no estamos pulsando boton
        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");
        //prefiero multiplicar speed por cada vector que necesto moveHorizontal y moveVertical, asi me ahorro multiplicar por 0f.
        Vector3 movement = new Vector3(moveHorizontal * speed, 0f, moveVertical * speed);
        rig.velocity = movement;
        // los limites de movimiento
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax), 0f, Mathf.Clamp(rig.position.z, boundary.zMin, boundary.zMax));
        //rotacion de la nave
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);
    }
}
