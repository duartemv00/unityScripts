using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class player : MonoBehaviour {
    public int health = 3;

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();

        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.x = data.position[0];
        position.x = data.position[0];
        transform.position = position;

    }
}