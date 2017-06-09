using UnityEngine;
using System.Collections;

public static class EnemyUtilities
{
    //Funcion para desactivar los elementos del enemigo. Es dicir, ocultarlos
    public static void deActiveEnemyElements (GameObject enemy)
    {
        //El ciclo obtiene el numero de hijos que el enemigo tiene y los oculta uno a uno
        for(int i = 0; i < enemy.transform.childCount; i++ ) enemy.transform.GetChild(i).gameObject.SetActive(false);
    }

    //Activar los elementos del enemigo segun sean el numero que se pase.
    public static void activeEnemyElements(GameObject enemy, int n)
    {
        for(int i = 0; i < n; i++) enemy.transform.GetChild(i).gameObject.SetActive(true);
    }

    public static void enemyDestruction(GameObject obj)
    {
        for (int i = 0; i <= 6; i++)
            if (obj.transform.GetChild(i).gameObject.activeSelf)
                obj.transform.GetChild(i).gameObject.GetComponent<genericBall>().ballExplosion();
    }

    public static int getEnemyResult(string enemyType, GameObject obj)
    {
        int result = 0;
        switch (enemyType)
        {
            //Si es un enemigo de suma, recorrer los enemigos activos
            case "sumEnemy":
                for (int i = 0; i <= 6; i++)
                {
                    if (obj.transform.GetChild(i).gameObject.activeSelf)
                    {
                        result += obj.transform.GetChild(i).gameObject.GetComponent<genericBall>().valor;
                    }
                }
                return result;
            default:
                return -1;
        }
    }

    //Funcion para obtener la posicion inical de donde se emite el enemigo.
    public static string setEnemyIniPos(float xPos, float yPos)
    {
        if (yPos >= 4.25f) return "up";
        else if (xPos >= 4.15) return "right";
        else if (yPos <= -4.25f) return "down";
        else return "left";
    }

    //Funcion para generar el numero de elementos en el enemigo segun el tiempo
    //Partida endless promedio 2 min
    public static int setEnemyBalls(float time)
    {
        if (time < 60.0f) return Random.Range(2, 3);
        else if (time >= 60.0f && time < 120.0f) return Random.Range(2, 4);
        else if (time >= 120.0f && time < 180.0f) return Random.Range(2, 5);
        else if (time >= 240.0f && time < 300.0f) return Random.Range(2, 6);
        else return Random.Range(2, 7);
    }

    //Funcion para establecer la velocidad del enemigo.
    //Se establece a partir del numero de elementos que tiene el enemigo y la posicion en la que se emite.
    public static float setEnemySpeed(int enemyEle, string enemyPos)
    {
        float speed;
        bool normal = false;
        //Si se emiten de los lados, la velocidad es normal
        //Si es por arriba o abjo, la velocidad es el doble.
        if (enemyPos == "left" || enemyPos == "right") normal = true;
        switch (enemyEle)
        {
            case 2:
                return speed = normal ? 1.5f : 2.0f;
            case 3:
                return speed = normal ? 1.0f : 1.25f;
            case 4:
                return speed = normal ? 0.5f : 0.75f;
            case 5:
                return speed = normal ? 0.25f : 0.5f;
            case 6:
                return speed = normal ? 0.15f : 0.30f;
            case 7:
                return speed = normal ? 0.10f : 0.20f;
            default:
                return speed = normal ? 1.5f : 3.0f;
        }
    }

    //Funcion calcular los puntos que se otorgan por enemigo.
    public static int setEnemyPoints(int enemyEle, string enemyType)
    {
        switch (enemyType)
        {
            case "sumEnemy":
                return enemyEle * 10;
            default:
                return 0;
        }
    }

    //Funcion para borrar los sprites de la result box, en caso de que el enemigo sea destruido por una respuesta correcta.
    public static void eraseResultBox()
    {
        GameObject rb = GameObject.Find("resultBoxBB");
        rb.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = null;
        rb.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = null;
        rb.GetComponent<AudioSource>().Play();
        rb.GetComponent<resultController>().number = -1;
    }

    //Funcion para actualizar el score.
    public static void updateScore(int points)
    {
        GameObject gc = GameObject.Find("GameController");
        gc.GetComponent<gameController>().score += points;
        gc.GetComponent<gameController>().scoreText.text = gc.GetComponent<gameController>().score.ToString();
    }

    //Funcion para obtener la referencia al result box y regresar el numero que tiene.
    public static int getResultBox()
    {
        GameObject rb = GameObject.Find("resultBoxBB");
        return rb.GetComponent<resultController>().number;
    }
}
