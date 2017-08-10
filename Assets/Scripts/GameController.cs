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

    //restartTxt es la variable para activar o desactivar el texto
    public Text restartText;
    private bool restartTxt;
    
    public GameObject restartGameObject;
    private bool restart;
    public GameObject gameOverGamwObject;
    private bool gameOver;
	// Use this for initialization
	void Start () {
        restart = false;
        restartGameObject.SetActive(false);
        //vamos a controlar tambien el texto de restart 'R'
        restartTxt = false;
        restartText.gameObject.SetActive(false);
        gameOver = false;
        gameOverGamwObject.SetActive(false);

        score = 0;
        updateScore();
        StartCoroutine(SpawnWaves());
	}
    private void Update()
    {
        if (restart && Input.GetKeyDown(KeyCode.R))
        {
            //aqui tenemos varias maneras de cargar una escena con el nombre "Main" o el index que es el numero en el buildsetting o las de abajo.
            
            Restart();
            //otra forma de hacerlo es obtener la escena que tenemos actualmente cargada 
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    //esta forma de hacerlo no la veo logica no me gusta, tendre que ver otra forma de hacerlo, lo mismo controlando el boton desde el private void Update()
    public void Restart()
    {
        SceneManager.LoadScene("Main");
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
                restartGameObject.SetActive(true);
                restart = true;
                //Esto de restartTxt y restartText.gameObject solo lo usare en la version de PC (Windows, Linux y Mac OS X)
                
                
                restartTxt = true;
                restartText.gameObject.SetActive(true);
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
        gameOverGamwObject.SetActive(true);
        gameOver = true;
        
    }
}
