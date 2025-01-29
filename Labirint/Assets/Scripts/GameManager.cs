using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum KeyColor { 
    Red,
    Green, 
    Gold
}

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    AudioSource audioSource;
    [SerializeField] int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;
    public string pauseEnd;

    public AudioClip resumeClip;
    public AudioClip pauseClip;
    public AudioClip winClip;
    public AudioClip loseClip;

    public Text timeText;
    public Text goldKeyText;
    public Text redKeyText;
    public Text greenKeyText;
    public Text crystalText;
    public Image snowFlake;
    public GameObject infoPanel;
    public Text reloadInfo;
    public Text useInfo;


    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        if (gameManager == null) {
            gameManager = this;
        }
        if (timeToEnd <= 0) {
            timeToEnd = 100;
        }
        snowFlake.enabled= false;
        timeText.text=timeToEnd.ToString();
        infoPanel.SetActive(false);
        reloadInfo.text = "";
        SetUseInfo("");

        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Stopper", 2, 1);
    }

    public void SetUseInfo(string info) { 
        useInfo.text = info;
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
        PickUpCheck();

        if (endGame) { 
            if (Input.GetKeyDown(KeyCode.Y)) 
            { SceneManager.LoadScene(0); } 
            if (Input.GetKeyDown(KeyCode.N)) 
            { Application.Quit(); } 
        }
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
        timeText.text = timeToEnd.ToString();
        snowFlake.enabled = false;
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
        PlayClip(pauseClip);
        Debug.Log("Igra pauzirana");
        useInfo.text = "Game Paused. Press P to resume.";
        infoPanel.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame() {
        PlayClip(resumeClip);
        Debug.Log("Nastavak igre");
        infoPanel.SetActive(false);
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
        infoPanel.SetActive(true);
        if (win) {
            PlayClip(winClip);
            Debug.Log("Pobijedio si! Igraj ponovno?");
            useInfo.text = "You won! Play again? Y/N";
        }
        else
        {
            PlayClip(loseClip);
            Debug.Log("Izgubio si! Igraj ponovno?");
            useInfo.text = "Game over. Try again? Y/N";
        }
    }

    public void AddPoints(int point) {
        points += point;
        crystalText.text = points.ToString();
    }
    public void AddTime(int addTime) {
        timeToEnd += addTime;
        timeText.text = timeToEnd.ToString();
    }
    public void FreezeTime(int freeze) {
        CancelInvoke("Stopper");
        snowFlake.enabled = true;
        InvokeRepeating("Stopper", freeze, 1);
    }

    public void AddKey(KeyColor color) {
        if (color == KeyColor.Red)
        {
            redKey++;
            redKeyText.text = redKey.ToString();
        }
        else if (color == KeyColor.Green)
        {
            greenKey++;
            greenKeyText.text = greenKey.ToString();
        }
        else if (color == KeyColor.Gold) {
            goldKey++;
            goldKeyText.text= goldKey.ToString();
        }
    }

    public void PlayClip(AudioClip playClip) {
        audioSource.clip = playClip;
        audioSource.Play();
    }

    public void WinGame() { win = true; endGame = true; }

}
