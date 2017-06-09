using UnityEngine;
using System.Collections;

public class numberKeyPress : MonoBehaviour {
	//Sprites para la animacion de los botones.
	public Sprite press;
	private Sprite normal;

	//Referencia a los objetos de juego que contiene la caja de resultados.
	//Para cambiar el sprite cada que se presiona el boton.
	public GameObject number1;
	public GameObject number2;
	//Referencia para modificar el numero en la caja del resultado
	public GameObject result;

	//Saber el numero que presiona.
	public Sprite numberClickedSprite;
	public int numberClicked;

	void Start(){
		normal = GetComponent<SpriteRenderer>().sprite;
		//Cambiar la posicion del segundo numero.
		number2.transform.localPosition = new Vector2(0.28f, 0.0f);
	} 

	void OnMouseDown(){
        //Reproducir el sonido del boton
        gameObject.GetComponent<AudioSource>().Play();

        //Cambiar el sprite del boton al presionado
        gameObject.GetComponent<SpriteRenderer>().sprite = press;

		//Si no hay nada en el resultado
		if (number1.GetComponent<SpriteRenderer> ().sprite == null){
			//Colocar el sprite en medio del result box.
			number1.transform.localPosition = new Vector2(0.0f, 0.0f);
			//Cambiar el sprite del resultbox
			number1.GetComponent<SpriteRenderer> ().sprite = numberClickedSprite;
			result.GetComponent<resultController>().number = numberClicked;
		}
		else {
			//Si ya esta lleno la primer digito, hacerlos mas pequeños y moverlos ligeramente
			//acoplar en el resultado
			if(number2.GetComponent<SpriteRenderer> ().sprite == null){
				//Mover el numero uno a la izquiera para que no se interpongan entre si.
				number1.transform.localPosition = new Vector2(-0.28f, 0.0f);
				//Cambiar el sprite del resultbox
				number2.GetComponent<SpriteRenderer> ().sprite = numberClickedSprite;
				//Realizar una conversion de los numeros en el resultbox, concatenar ambos
				int numberInt;
				string numConcat = result.GetComponent<resultController>().number.ToString() + numberClicked.ToString();
				numberInt = int.Parse (numConcat);
				result.GetComponent<resultController>().number = numberInt;
			}
		}
	}

	//Cambiar el sprite del boton al normal.
	void OnMouseUp(){
		gameObject.GetComponent<SpriteRenderer>().sprite = normal;
	}
}
