using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject asteroidHazard;
    public Vector3 spawnValues;
	// Use this for initialization
	void Start () {
        SpawnWaves();
	}
	
	// Update is called once per frame
    //Metodo para instanciar los asteroides de momento
	void SpawnWaves () {
        //Lo vamos a poner de la otra forma declarando los valores de x, y, z, por qué asi podremos poner aleatoriamente la X en cada asteroide.
        //Vector3 spawnPosition = spawnValues;
        //aqui crearemos la posicion del asteroide de forma aleatoria en el eje X.
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Instantiate(asteroidHazard, spawnPosition, Quaternion.identity);
	}
}
