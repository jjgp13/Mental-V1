using UnityEngine;
using System.Collections;

public class deleteKeyPress : MonoBehaviour {

	//Sprites para la animacion de los botones.
	public Sprite press;
	private Sprite normal;


	public GameObject number1;
	public GameObject number2;
	public GameObject result;

	void Start(){
		normal = GetComponent<SpriteRenderer>().sprite;
	} 

	//Cuando se presione el boton
	void OnMouseDown(){
        //Reproducir el sonido del boton
        gameObject.GetComponent<AudioSource>().Play();

		//Cambiar el sprite del boton al presionado
		gameObject.GetComponent<SpriteRenderer>().sprite = press;

		//Borrar el sprite y el resultado que tiene el GameObject
		number1.GetComponent<SpriteRenderer> ().sprite = null;
		number2.GetComponent<SpriteRenderer> ().sprite = null;
		result.GetComponent<resultController>().number = -1;
	}

	//Cambiar el sprite del boton al normal.
	void OnMouseUp(){
		gameObject.GetComponent<SpriteRenderer>().sprite = normal;
	}
}
