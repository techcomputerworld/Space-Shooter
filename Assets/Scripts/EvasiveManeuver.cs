using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {

    /* nosotros queremos paara hacerlo mas real que el tiempo sea aleatoria entre un valor minimo y un valor maximo 
     * startWait.x sera el valor minimo y startWait.y sera el valor maximo que durara la maniobra 
     */
     // dodge como verbo esquivar como sustantivo evasion, velocidad maxima con la que va a hacer la evasion.
    public float dodge; 
    public Vector2 startWait;
    //smothing es en ingles suavizado
    public float smothing;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;
    public float tilt;
    //velocidad con la que va a hacer la maniobra de evasion 
    private float targetManeuver;
    private Rigidbody rb;
    // Use this for initialization
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start () {
        UpdateBoundary();
        StartCoroutine(Evade());
	}
    //Define Boundary for enemy ship, According to the size of the screen that we have.
    //Definiendo los limites para la nave enemiga, segun el tamaño de la pantalla que tengamos. 
    void UpdateBoundary()
    {
        Vector2 half = Utils.GetHalfDimensionsInWorldUnits();

        //xMin -6 
        //xMax 6 
        //zMin -4
        //zMax 8 

        boundary.xMin = -half.x + 0.9f;
        boundary.xMax = half.x - 0.9f;
        boundary.zMin = -half.y + 6.8f;
        boundary.zMax = half.y - 2f;
        //Debug.Log(half);

    }

    IEnumerator Evade()
    {
        
        //esperar tiempo concreto
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        //Mathf.Sign(transform.position.x) devuelve positivo +1 si la x vale 0 o mas y devuelve -1 si la x vale un valor negativo.
        //targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x); //tambien se puede poner como * (transform.position.x<0 ? -1 : 1); esto es un ternario. 
        //targetManuever aqui he hecho una variación de como esta en el tutorial por que no me ha gustado con tan poca maniobra y lo he hecho asi.
        //English: Is a variation of oficial tutorial I like with more maneuver
        while (true)
        {
            targetManeuver = Random.Range(3, dodge) * -(transform.position.x > 0 ? 1 : -1);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }

    }
	// Update is called once per frame
	void FixedUpdate () {
        float newManeuever = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smothing);
        rb.velocity = new Vector3(targetManeuver, 0.0f, rb.velocity.z);
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 0f, rb.position.z);
        rb.rotation = Quaternion.Euler(0f, 0f, rb.velocity.x * -tilt);
        //vamos a poner 
        //Debug.Log(newManeuever);
        //Debug.Log(rb.velocity);
    }

}
