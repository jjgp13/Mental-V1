using UnityEngine;
using System.Collections;

public class genericEnemy : MonoBehaviour {
    //Referencia al controller de la scene para tener el tiempo
	GameObject gameController;

    //Variables para incializar el enemigo
    //Establcer en el orden en que se declaran
    public string enemyType;
    int enemyElements;
    public int enemyResult;
    Vector2 enemySpawnPos;
    public string enemySpawnPosS;
    public float enemySpeed;
    public int enemyPoints;

    /*
		randomType: elegir al azar una funcion de movimiento
		randomDisType: otorgar un desplzamiento en grafica para que sea diferente cada vez
		Desplazamiento: derecha-izquierda, arriba-abajo, ambas.
	*/
    public int randomType, randomDisType, invert;
	
    //Rango de desplzamiento en la grafica.
	public float randomDis;

	//Activar el objeto cuando entra al campo de juego
	public bool inField;

    /*public genericEnemy(int numBalls, float speed, string iniPos){
        enemyElements = numBalls;
        enemySpeed = speed;
        enemySpawnPos = EnemyUtilities.setEnemyIniPos(iniPos);
        enemySpawnPosS = iniPos;
    }*/
	
	// Use this for initialization
	void Start () {
		//Obtener el objeto controlador para determinar el tiempo y con ello la velocidad.
		gameController = GameObject.Find("GameController");

        //Desactivar las pelotas de alrededor de la central
        EnemyUtilities.deActiveEnemyElements(gameObject);

        //Establecer el tipo de enemigo
        enemyType = "sumEnemy";

        //Establecer el numero de elementos del enemigo segun el tiempo de juego.
        enemyElements = EnemyUtilities.setEnemyBalls(gameController.GetComponent<gameController>().gameTime);
        //Activar en pantalla el numero de elementos del enemigo
        EnemyUtilities.activeEnemyElements(gameObject, enemyElements);

        //Obtener el resultado del enemigo, a partir de su tipo.
        //Dependiendo del tipo es como se calculca el resultado.
        enemyResult = EnemyUtilities.getEnemyResult(enemyType, gameObject);

        //Obtener la posicicion en la que se emite el enmigo
        //Obtener la posicion inicial de donde se emite el enemigo.
        enemySpawnPos.x = gameObject.transform.position.x;
        enemySpawnPos.y = gameObject.transform.position.y;
        enemySpawnPosS = EnemyUtilities.setEnemyIniPos(enemySpawnPos.x, enemySpawnPos.y);
        
        //Establecer la velocidad del enemigo, segun el tipo y la posicion en que se emite
        enemySpeed = EnemyUtilities.setEnemySpeed(enemyElements, enemySpawnPosS);

        //Establecer los puntos que se generar por eliminar al enemigo
        enemyPoints = EnemyUtilities.setEnemyPoints(enemyElements, enemyType);

		randomType = 0;
		randomDisType = Random.Range(0, 2);
		randomDis = Random.Range(-2.0f, 2.0f);
		invert = Random.Range(0,99);
        inField = false;

		//Si es una funcion exponencial, disminuir la velocidad.
		//Cuadrado
		if(randomType == 1) enemySpeed = 1.0f;
		//Cubo
		if(randomType == 2) enemySpeed = 0.75f;
	}
	
	// Update is called once per frame
	void Update () {
        //De arriba hacia abajo
        if (enemySpawnPosS == "up")
        {
            EnemyMovements.moveUpToDown(gameObject, enemySpeed);
            //movement(randomType);
        }

        //Derecha a izquierda
        if (enemySpawnPosS == "right")
        {
			EnemyMovements.moveRightToLeft(gameObject, enemySpeed);
			//movement(randomType);
		}
		//Izquierda a Derecha.
		if(enemySpawnPosS == "left")
        {
            EnemyMovements.moveLeftToRight(gameObject, enemySpeed);
			//movement(randomType);
		}

        //De abajo hacia arriba
		if(enemySpawnPosS == "down")
        {
            EnemyMovements.moveDownToUp(gameObject, enemySpeed);
			//movement(randomType);
		}

		//Una vez dentro de la pantalla activar
		if(inField){
			StartCoroutine(checkResult());
		}
	}

	void movement(int randomType){
		switch (randomType){
			//Mover con funcio seno
			case 0:
				EnemyMovements.moveSin(gameObject, randomDis, randomDisType, enemySpawnPos.x, invert);
				break;
			case 1:
                EnemyMovements.moveX2(gameObject, randomDis, randomDisType, enemySpawnPos.x, invert);
				break;
			case 2:
                EnemyMovements.moveX3(gameObject, randomDis, randomDisType, enemySpawnPos.x, invert);
				break;
			//Mover en diagonal
			default:
				if(enemySpawnPosS == "right" || enemySpawnPosS == "left"){
                    if (enemySpawnPos.y > 2.0f) EnemyMovements.moveUpToDown(gameObject, enemySpeed);
					if(enemySpawnPos.y < -2.0f) EnemyMovements.moveDownToUp(gameObject, enemySpeed);
				}
				if(enemySpawnPosS == "up" || enemySpawnPosS == "down"){
                    if (enemySpawnPos.x > 2.0f) EnemyMovements.moveRightToLeft(gameObject, enemySpeed);
					if(enemySpawnPos.x < -2.0f) EnemyMovements.moveLeftToRight(gameObject, enemySpeed);
				}
				break;
		}
	}

	//Checar el resultado
	IEnumerator checkResult(){
		if(EnemyUtilities.getResultBox() == enemyResult){
            //Detener al enemigo
            enemySpeed = 0.0f;
            //Animación destrucción.
            EnemyUtilities.enemyDestruction(gameObject);

            //Borrar la caja de resultados
            yield return new WaitForSeconds(0.1f);
            EnemyUtilities.eraseResultBox();

            //Actualizar el score
			yield return new WaitForSeconds(0.3f);
            EnemyUtilities.updateScore(20);
            Destroy(gameObject);
		}
	}
}