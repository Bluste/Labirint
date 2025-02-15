using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    public KeyColor color;
    public Material red;
    public Material green;
    public Material gold;

    // Start is called before the first frame update
    void Start()
    {
        SetMyColor();
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    public override void Picked()
    {
        GameManager.gameManager.AddKey(color);
        Destroy(this.gameObject);
    }
    void SetMyColor()
    {
        switch (color)
        {
            case KeyColor.Red:
                GetComponent<Renderer>().material = red;
                break;
            case KeyColor.Green:
                GetComponent<Renderer>().material = green;
                break;
            case KeyColor.Gold:
                GetComponent<Renderer>().material = gold;
                break;
        }
    }

}
