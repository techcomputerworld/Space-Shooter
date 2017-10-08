using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverShip01 : MonoBehaviour {

    //boundary lo utilizo para establecer limites de movimiento en la Ship01
    public Boundary boundary;
    public float speed;
    [Header("move left and right")]
    public float targetMove;
    public float dodge;
    public float smothing;
    public Vector2 moveTime;
    public Vector2 moveWait;

    // el giro sobre el eje Z que hara la nave
    public float tilt;
    public Vector2 startWait;
    private Rigidbody rig;
    private bool stopEjeZ = false;
    private bool stopEjeX = false;
    //Aqui en este vector trabajamos con el eje Z 
    private Vector3 positionZ;
    //Aqui en este vector trabajamos con el eje X
    private Vector3 positionX;
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {
        rig.velocity = transform.forward * speed;
        //positionZ = new Vector3(rig.position.x, 0f, Mathf.Clamp(rig.position.z, 7.5f, 7));
        //positionX = new Vector3(Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax), 0f, rig.position.z);

    }
	
	// Update is called once per frame
	void Update () {
        //este valor tiene que estar entre zMin = 7 y zMax = 10
        //float Range = 7f;
       
        
        Debug.Log(positionZ + "Position Z");
        float ejeX = rig.position.x;
        float ejeZ = rig.position.z;
        
        if (ejeZ <= positionZ.z)
        {
            stopShip();
            StartCoroutine(Evade());
        }
        
    }
    private void FixedUpdate()
    {
        float ejeX = rig.position.x;
        float ejeZ = rig.position.z;

        if (ejeZ <= 7.1f)
        {
            stopShip();
            StartCoroutine(Evade());
        }
    }

    private void stopShip()
    {
        rig.isKinematic = true;
        rig.velocity = Vector3.zero;
        stopEjeZ = true;
    }
   
    private void moveRight()
    {
        rig.isKinematic = false;
        //Vector3 movement = new Vector3(moveHorizontal * speed, 0f, moveVertical * speed);
        //rig.velocity = movement;
        Vector3 movement = new Vector3(1 * speed, 0f, 0f);
        rig.velocity = movement;
        Debug.Log("Velocity: " + rig.velocity);
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);
        Debug.Log("Rotacion: " + rig.rotation);
        //establecer limite
        //aleatoriamente que se pare en el eje X entre -6.5 y 6.5


    }
    private void moveLeft()
    {
        rig.isKinematic = false;
        //Vector3 movement = new Vector3(moveHorizontal * speed, 0f, moveVertical * speed);
        //rig.velocity = movement;
        Vector3 movement = new Vector3(-1 * speed, 0f, 0f);
        rig.velocity = movement;
        Debug.Log("Velocity: " + rig.velocity);
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);
        Debug.Log("Rotacion: " + rig.rotation);
        //establecer limite 
        //aleatoriamente que se pare en el eje X entre -6.5 y 6.5


    }
    IEnumerator Evade()
    {
        bool finalMove = false; 
        rig.isKinematic = false;
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        targetMove = rig.position.x <= 0 ? 1 : -1;
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(moveTime.x, moveTime.y));
            
            if (targetMove == 1)
            {
                moveRight();
                while (rig.position.x <= 6.50)
                {
                    Debug.Log(rig.position.x);
                }
                stopShip();
            }
            if (targetMove == -1)
            {
                moveLeft();
                while (rig.position.x >= -6.50)
                {
                    Debug.Log(rig.position.x);
                }
                stopShip();
            }
        }
    }
    /*
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(targetMove * dodge, 0f, 0f);
        //float newMove = Mathf.MoveTowards(rig.velocity.x, targetMove, Time.deltaTime * smothing);
        rig.velocity = new Vector3(targetMove, 0.0f, rig.velocity.z);
        //rig.position = new Vector3(Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax), 0f, rig.position.z);
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);
        
    }
    */
}
