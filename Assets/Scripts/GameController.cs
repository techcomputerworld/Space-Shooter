using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject asteroidHazard;
    public Vector3 spawnValues;
    public int asteroidHazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    //la score solo la vamos a manejar desde esta clase y no hace falta manipular su valor desde el inspector. Por tanto mejor private. 
    private int score;
    public Text scoreText;

    public Text restartText;
    private bool restart;
    public Text gameOverText;
    private bool gameOver;
	// Use this for initialization
	void Start () {
        restart = false;
        restartText.gameObject.SetActive(false);
        gameOver = false;
        gameOverText.gameObject.SetActive(false);

        score = 0;
        updateScore();
        StartCoroutine(SpawnWaves());
	}
    private void Update()
    {
        if (restart && Input.GetKeyDown(KeyCode.R))
        {
            //aqui tenemos varias maneras de cargar una escena con el nombre "Main" o el index que es el numero en el buildsetting o las de abajo.
            SceneManager.LoadScene("Main");
            //otra forma de hacerlo es obtener la escena que tenemos actualmente cargada 
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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

            if (gameOver)
            {
                restartText.gameObject.SetActive(true);
                restart = true;
                break;
            }
        }
        
        
	}

    public void AddScore(int value)
    {
        score += value;
        updateScore();
    }

    void updateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
        
    }
}
