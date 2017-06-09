using UnityEngine;
using System.Collections;

public static class EnemyMovements
{
    //////////////////////////////////Movimiento de los enemigos//////////////////////////////////
    //De arriba hacia abajo
    public static void moveUpToDown(GameObject obj, float velocity)
    {
        obj.transform.Translate(Vector2.down * velocity * Time.deltaTime);
    }
    //De abajo hacia arriba
    public static void moveDownToUp(GameObject obj, float velocity)
    {
        obj.transform.Translate(Vector2.up * velocity * Time.deltaTime);
    }
    //De izquierda a derecha
    public static void moveLeftToRight(GameObject obj, float velocity)
    {
        obj.transform.Translate(Vector2.right * velocity * Time.deltaTime);
    }
    //De derecha a izquierda
    public static void moveRightToLeft(GameObject obj, float velocity)
    {
        obj.transform.Translate(Vector2.left * velocity * Time.deltaTime);
    }

    //Seno 
    public static void moveSin(GameObject obj, float dis, int disType, float iniPos, int invert)
    {
        float xPos, yPos;
        //La posicion de x va a ser elegida en el script de genericEnemy.
        //Solamente determinara si va de izquierda a derecha o vicesversa.
        xPos = obj.transform.position.x;
        yPos = obj.transform.position.y;

        //Si la posicion inicial del objeto en x es alguna de esas, y depende de x
        if (iniPos == 4.15f || iniPos == -4.15f)
        {
            if (disType == 0) yPos = Mathf.Sin(xPos + dis) + dis;
            else if (disType == 1) yPos = Mathf.Sin(xPos) + dis;
            else yPos = Mathf.Sin(xPos + dis);
            //Actualizar la posicion
            if (invert < 50) obj.transform.position = new Vector2(xPos, yPos);
            else obj.transform.position = new Vector2(xPos, -yPos);
            //Sino x depende de y, es decir, incia arriba o abajo.
        }
        else
        {
            if (disType == 0) xPos = Mathf.Sin(yPos + dis) + dis;
            else if (disType == 1) xPos = Mathf.Sin(yPos) + dis;
            else xPos = Mathf.Sin(yPos + dis);
            //Actualizar la posicion
            if (invert < 50) obj.transform.position = new Vector2(xPos, yPos);
            else obj.transform.position = new Vector2(-xPos, yPos);
        }
    }

    // x * x
    public static void moveX2(GameObject obj, float dis, int disType, float iniPos, int invert)
    {
        float xPos, yPos;
        //La posicion de x va a ser elegida en el script de genericEnemy.
        //Solamente determinara si va de izquierda a derecha o vicesversa.
        xPos = obj.transform.position.x;
        yPos = obj.transform.position.y;

        //Si la posicion inicial del objeto en x es alguna de esas, y depende de x
        if (iniPos == 4.15f || iniPos == -4.15f)
        {
            if (disType == 0) yPos = Mathf.Pow(xPos + dis, 2.0f) + dis;
            else if (disType == 1) yPos = Mathf.Pow(xPos, 2.0f) + dis;
            else yPos = Mathf.Pow(xPos + dis, 2.0f);
            //Actualizar la posicion
            if (invert < 50) obj.transform.position = new Vector2(xPos, yPos);
            else obj.transform.position = new Vector2(xPos, -yPos);
        }
        else
        {
            if (disType == 0) xPos = Mathf.Pow(yPos + dis, 2.0f) + dis;
            else if (disType == 1) xPos = Mathf.Pow(yPos, 2.0f) + dis;
            else xPos = Mathf.Pow(yPos + dis, 2.0f);
            //Actualizar la posicion
            if (invert < 50) obj.transform.position = new Vector2(xPos, yPos);
            else obj.transform.position = new Vector2(-xPos, yPos);
        }
    }

    // x * x * x
    public static void moveX3(GameObject obj, float dis, int disType, float iniPos, int invert)
    {
        float xPos, yPos;
        //La posicion de x va a ser elegida en el script de genericEnemy.
        //Solamente determinara si va de izquierda a derecha o vicesversa.
        xPos = obj.transform.position.x;
        yPos = obj.transform.position.y;

        //Si la posicion inicial del objeto en x es alguna de esas, y depende de x
        if (iniPos == 4.15f || iniPos == -4.15f)
        {
            if (disType == 0) yPos = Mathf.Pow(xPos + dis, 3.0f) + dis;
            else if (disType == 1) yPos = Mathf.Pow(xPos, 3.0f) + dis;
            else yPos = Mathf.Pow(xPos + dis, 3.0f);
            //Actualizar la posicion
            if (invert < 50) obj.transform.position = new Vector2(xPos, yPos);
            else obj.transform.position = new Vector2(xPos, -yPos);
        }
        else
        {
            if (disType == 0) xPos = Mathf.Pow(yPos + dis, 3.0f) + dis;
            else if (disType == 1) xPos = Mathf.Pow(yPos, 3.0f) + dis;
            else xPos = Mathf.Pow(yPos + dis, 3.0f);
            //Actualizar la posicion
            if (invert < 50) obj.transform.position = new Vector2(xPos, yPos);
            else obj.transform.position = new Vector2(-xPos, yPos);
        }
    }
}
