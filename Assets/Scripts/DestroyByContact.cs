using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    //esta variable tipo GameObject pondre la explosión 
    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;
    private GameController gameController;

    //vamos a realizar una pequeña prueba y vamos a instanciar el objeto GameController en el metodo Awake despues de hacerlo en el Start 
    private void Start()
    {
       
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        //a mi me  gusta trabajar mejor con una sola linea que con varias para hacer lo mismo, esto tb se puede escribir asi
        //GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        //gameController = gameControllerObject.GetComponent<GameController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log(other.name);
        //if (other.tag == "Boundary") return;
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))  return;
        //Debug.Log(other.name);
        //esta forma de hacerlo, no me convence porque el disparo del enemigo deberia hacer una explosion junto con el objeto con el que colisiona por ejemplo la nave,
        // del jugador. 
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        
        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
