using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null) {
            gameManager = this;
        }
        if (timeToEnd <= 0) {
            timeToEnd = 100;
        }
        InvokeRepeating("Stopper", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
    }
    void Stopper() {
        timeToEnd--;
        Debug.Log("Preostalo vrijeme: " + timeToEnd + " s");

        if (timeToEnd <= 0) {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame) {
            EndGame();
        }
    }

    public void PauseGame() {
        Debug.Log("Igra pauzirana");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame() {
        Debug.Log("Nastavak igre");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void PauseCheck() {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (gamePaused)
            {
                ResumeGame();
            }
            else 
            {
                PauseGame();
            }
        }
    }

    public void EndGame() {
        CancelInvoke("Stopper");
        if (win) {
            Debug.Log("Pobijedio si! Igraj ponovno?");
        }
        else 
        {
            Debug.Log("Izgubio si! Igraj ponovno?");
        }
    }
}
