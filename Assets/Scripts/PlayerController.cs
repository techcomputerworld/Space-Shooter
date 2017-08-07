using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {
    
    public float speed;
    //tilt es giro
    public float tilt;
    public Boundary boundary;

    private Rigidbody rig;
    // Use this for initialization
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
		

	}
    private void FixedUpdate()
    {
        //Para mover en horizontal  la nave, el boton negativo izquierda y positivo derecha. valores entre -1 y 1, 0 si no estamos pulsando boton
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");
        //prefiero multiplicar speed por cada vector que necesto moveHorizontal y moveVertical, asi me ahorro multiplicar por 0f.
        Vector3 movement = new Vector3(moveHorizontal * speed, 0f, moveVertical * speed);
        rig.velocity = movement;
        // los limites de movimiento
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax), 0f, Mathf.Clamp(rig.position.z, boundary.zMin, boundary.zMax));
        //rotacion de la nave
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);
    }
}
