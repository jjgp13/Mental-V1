using UnityEngine;
using System.Collections;

public class resultController : MonoBehaviour {

	//Resultado del objeto de juego.
	//Si es solo un número se toma el de number1.
	//Sino se concatena y se toma el del number2.
	public int number;

	void Start(){
		//Comenzar ambos en -1 para que no haya conflictos con los enemigos que tiene 0 como resultado
		number = -1;
	}
}