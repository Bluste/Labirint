using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    bool iCanOpen = false;
    public Renderer myLock;
    public Material red;
    public Material green;
    public Material gold;


    public Door[] doors;
    public KeyColor myColor;
    bool locked = false;
    Animator key;
    // Start is called before the first frame update
    void Start()
    {
        key = GetComponent<Animator>();
        SetMyColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && iCanOpen && !locked)
        {
            key.SetBool("useKey", CheckTheKey());
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { 
            iCanOpen = true;
            Debug.Log("Stojis na pravom mjestu.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            iCanOpen = false;
            Debug.Log("Ne stojis vise na dobrom mjestu.");
        }
    }

    public void UseKey() {
        foreach (Door door in doors)
        {
            door.Open();
        }
    }

    public bool CheckTheKey() {
        if (GameManager.gameManager.redKey > 0 && myColor == KeyColor.Red)
        {
            GameManager.gameManager.redKey--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.greenKey > 0 && myColor == KeyColor.Green)
        {
            GameManager.gameManager.greenKey--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.goldKey > 0 && myColor == KeyColor.Gold)
        {
            GameManager.gameManager.goldKey--;
            locked = true;
            return true;
        }
        else {
            Debug.Log("Nemate odgovarajuci kljuc!");
            return false;
        }
    }

    void SetMyColor() {
        switch (myColor) {
            case KeyColor.Red:
                GetComponent<Renderer>().material = red;
                myLock.material = red;
                break;
            case KeyColor.Green:
                GetComponent<Renderer>().material = green;
                myLock.material = green;
                break;
            case KeyColor.Gold:
                GetComponent<Renderer>().material = gold;
                myLock.material = gold;
                break;
        }
    }
}
