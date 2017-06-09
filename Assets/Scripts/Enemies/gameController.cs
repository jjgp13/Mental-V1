using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {

    //referncia al teclado para ocultarlo
    public GameObject keyBoard;
    //Panel para el menu cuando pierde el jugador.
    public GameObject panel;
    public Text finalScore, bestScore;

    //Vectores donde se emiten los enemigos.
    public Vector2 spawnUp, spawnLeft, spawnDown, spawnRight;
	//Arreglo de sprites para cargar los sprites de los numeros en las pelotas.
	public Sprite[] spriteNumbers = new Sprite[10];
	//Referencias para los enemigos.(Arreglos cuando esten todos).
	public GameObject enemy;
	//Variable para almacenar el timepo de una partida.
	public float gameTime;
	//Variable para almacenar la velocidad con la que se 
	public float velocity;
	public float velChanger;

    //Variable para almacenar el score.
    public int score;
    public Text scoreText;

    //Texto para esperar 3 segundo para que empiece el juego
    public Text startTime;
    float st;


    //Variable para saber si no ha peridio el usuario
    bool alive;

	void Start(){
        //timepo de espera para que el usuario se prepare
        st = 3;
        startTime.gameObject.SetActive(true);

        //Habilitar el teclado.
        keyBoard.SetActive(true);
        //Desabilitar el panel.
        panel.SetActive(false);
        //Habilitar el score y ponerlo en 0
        scoreText.gameObject.SetActive(true);
        score = 0;

        //El usuario esta vivo al inicio del juego
        alive = true;

		//Incializar la corrutina de spawnEnemy
		StartCoroutine(spawnEnemy());
		//Incializar el tiempo de juego en 0
		gameTime = 0.0f;
		velocity = 1.0f;
		velChanger = 0.0f;
	}

	void Update(){
        if (st > 0)
        {
            st -= Time.deltaTime;
            startTime.text = Mathf.Ceil(st).ToString();
        }
        else startTime.gameObject.SetActive(false);

		gameTime += Time.deltaTime;
		velChanger += Time.deltaTime;
		if(velChanger > 30.0f){
			velChanger = 0.0f;
			velocity += 0.1f;
		}
	}

	//Funcion para lanzar los globos.
	IEnumerator spawnEnemy(){
        yield return new WaitForSeconds(3.0f);
        while (alive){
			changeSpawnPositions();
            int randPos = Random.Range(0, 99);
			Quaternion spawnRotation = Quaternion.identity;
            if (randPos < 25) Instantiate (enemy, spawnUp, spawnRotation);
			else if(randPos >= 25 && randPos < 50) Instantiate (enemy, spawnRight, spawnRotation);
			else if(randPos >= 50 && randPos < 75) Instantiate (enemy, spawnDown, spawnRotation);
			else Instantiate (enemy, spawnLeft, spawnRotation);
			yield return new WaitForSeconds (3.0f);
		}
	}

	void changeSpawnPositions(){
		spawnUp = new Vector2(Random.Range(-2.15f, 2.15f), 4.25f);
        spawnRight = new Vector2(4.15f, Random.Range(-2.40f, 2.40f));
        spawnDown = new Vector2(Random.Range(-2.15f, 2.15f), -4.25f);
		spawnLeft = new Vector2(-4.15f, Random.Range(-2.40f, 2.40f));
	}

	//Destruir el objetos cuando salga de campo visible
	void OnTriggerExit2D(Collider2D other){
		Destroy(other.gameObject);
        alive = false;
        StopCoroutine(spawnEnemy());
        StartCoroutine(gameOver());
	}

	void OnTriggerEnter2D(Collider2D other){
        //Entra al collider
		other.gameObject.GetComponent<genericEnemy>().inField = true;
        //Calcular el resultado del enemigo.
        other.gameObject.GetComponent<genericEnemy>().enemyResult = EnemyUtilities.getEnemyResult(other.gameObject.GetComponent<genericEnemy>().enemyType, other.gameObject);
        //Emitir el sonido
        other.gameObject.GetComponent<AudioSource>().Play();
    }

    IEnumerator gameOver()
    {
        GetComponent<AudioSource>().loop = false;
        scoreText.gameObject.SetActive(false);
        keyBoard.SetActive(false);
        panel.SetActive(true);
        saveScore(score);
        finalScore.text = score.ToString();
        bestScore.text = PlayerPrefs.GetInt("Score").ToString();
        yield return new WaitForSeconds(1.0f);
    }

    //Funcion para la UI, una vez que el usario pierde
    //Regresar a la scena princial
    public void returnMainScene()
    {
        SceneManager.LoadScene("main");
    }

    //Recargar la scene
    public void roloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void saveScore(int score)
    {
        //Si es la primera que se juega
        if (PlayerPrefs.GetInt("Score") == 0) PlayerPrefs.SetInt("Score", score);
        //Si ya hay scores guardados.
        if (PlayerPrefs.GetInt("Score") < score) PlayerPrefs.SetInt("Score", score);
    }
}
