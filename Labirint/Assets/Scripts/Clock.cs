using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    public int time = 5;
    public bool addTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    public override void Picked()
    {
        int sign;
        if (addTime)
        {
            sign = 1;
        }
        else {
            sign = -1;
        }
        GameManager.gameManager.AddTime((int)time * sign);
        Destroy(this.gameObject);
    }
}
