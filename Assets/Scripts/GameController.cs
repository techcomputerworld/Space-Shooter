using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject asteroidHazard;
    public Vector3 spawnValues;
    public int asteroidHazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnWaves());
	}
	
	// Update is called once per frame
    //Metodo para instanciar los asteroides de momento
	IEnumerator SpawnWaves () {
        //Lo vamos a poner de la otra forma declarando los valores de x, y, z, por qué asi podremos poner aleatoriamente la X en cada asteroide.
        //Vector3 spawnPosition = spawnValues;
        //aqui crearemos la posicion del asteroide de forma aleatoria en el eje X.
        
        while (true) /* estara ejecutandose hasta que la escena deje de existir por ejemplo la nave sea destruida */
        {
            for (int i = 0; i < asteroidHazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(asteroidHazard, spawnPosition, Quaternion.identity);
                //ejecutar la instruccion que detiene la courutine 
                yield return new WaitForSeconds(spawnWait);

            }
            yield return new WaitForSeconds(waveWait);
        }
        
        
	}
}
