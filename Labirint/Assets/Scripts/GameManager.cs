using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public enum KeyColor { 
    Red,
    Green, 
    Gold
}

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;

    public int points = 0;
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
        PickUpCheck();
    }
    void PickUpCheck()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Actual Time: " + timeToEnd);
            Debug.Log("Key red: " + redKey + " green: " + greenKey + " gold: " + goldKey);
            Debug.Log("Points: " + points);
        }
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

    public void AddPoints(int point) {
        points += point;
    }
    public void AddTime(int addTime) {
        timeToEnd += addTime;
    }
    public void FreezeTime(int freeze) {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freeze, 1);
    }

    public void AddKey(KeyColor color) {
        if (color == KeyColor.Red)
        {
            redKey++;
        }
        else if (color == KeyColor.Green)
        {
            greenKey++;
        }
        else if (color == KeyColor.Gold) {
            goldKey++;
        }
    }
}
