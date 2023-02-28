using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject pause;
    public GameObject linterna;
    public GameObject player;
    public GameObject player2;

    playerMov playerMov;

    bool _pausa;
    
    // Start is called before the first frame update
    void Awake()
    {
        playerMov = gameObject.GetComponent<playerMov>();
    }

    // Update is called once per frame
    void Update()
    {
        //PAUSE THE GAME
        if (Input.GetButtonDown("Cancel")) {
            if (_pausa){ //si estamos en pausa
                ResumeGame();
            } else { //si NO estaos en pausa
                PauseGame();
            }
        }
        
    }

    public void PauseGame ()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
        linterna.SetActive(false);
        _pausa = true;
        player.SetActive(false);
        player2.SetActive(true);
        player2.transform.position = player.transform.position;
        //playerMov.enabled = false;
    }

    public void ResumeGame ()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
        linterna.SetActive(true);
        _pausa = false;
        player.SetActive(true);
        player2.SetActive(false);
    } 

    public void RestartGame () {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    void timeScaleUno() {
        Time.timeScale = 1;
    }

    public void Quit() {
        Application.Quit();
    }

}
