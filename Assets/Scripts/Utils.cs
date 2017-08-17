using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils { 
    public static Vector2 GetHalfDimensionsInWorldUnits()
    {
        float width, height;

        Camera cam = Camera.main;
        /* el height lo hemos calculado por medio de Size de la camara que lo tengo 11.8 unidades */
        // son nuneros enteros hacemos un casting en el divisor y nos devolvera un numero float 
        float ratio = cam.pixelWidth / (float)cam.pixelHeight;
        height = cam.orthographicSize * 2;
        width = height * ratio;


        return new Vector2(width, height) / 2f;
    }
	
}
