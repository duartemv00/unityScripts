using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Using
//Using XML o JSON files -> BUT the are easy to modify
//Using Custom Binary Files -> NICE

[System.Serializable]
public class PlayerData {
    //Crear variables de los datos que quieres guardar (string, bool, float, int[])
    
    public int health;
    
    //Tipos de datos como Vector o Color no se pueden guardar
    //Vector se puede transformar en un float[3]

    public float[] position;

    //Color se puede transformar en un

    public PlayerData (Player player) {
        health = player.health;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        
    }


    //Ahora hay que transformarlo todo a binario y almacenarlo en un fichero.
    //Y cuando sea necesario leer ese fichero para recuperar los datos.
}