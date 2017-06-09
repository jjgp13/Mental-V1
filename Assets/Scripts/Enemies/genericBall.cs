using UnityEngine;
using System.Collections;

public class genericBall : MonoBehaviour {
	//Animacion de explosion
	Animator animController;
	//Valor de la pelota
	public int valor;
	//Referencia al hijo de la pelota, el cual es el sprite del numero
	GameObject number;
	//Referencia el gamecontroller de la escena, el cual contiene los numeros. (Para no cargarlos en cada objeto).
	GameObject numbersController;

	void Start(){
        //Asignar el hijo como el sprite del numero
        number = gameObject.transform.GetChild(0).gameObject;
        //Encontrar el Controller para asignar los numeros
        numbersController = GameObject.Find("GameController");
		//Obtener el animController
		animController = GetComponent<Animator>();
		//Generar un valor aleatorio
		valor = Random.Range(1, 9);
		//Seleccionar el sprite a partir del numero generado aleatoriamente.
		number.GetComponent<SpriteRenderer>().sprite = numbersController.GetComponent<gameController>().spriteNumbers[valor]; 
	}

	//Funcion para la animacion de destruccion de la pelota
	public void ballExplosion(){
		//Ocultar el sprite del numero.
		this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = null;

		//Ejecutar la animación de la explosion.
		animController.SetBool("explote", true);

	}
}
