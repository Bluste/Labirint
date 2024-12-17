using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotationAxis { 
    x,y,z
}
public class PickUp : MonoBehaviour
{
    public RotationAxis rotationAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    public virtual void Picked() {
        Debug.Log("PickUp skupljen!");
        Destroy(gameObject);
    }

    public void Rotation() {
        switch (rotationAxis)
        {
            case RotationAxis.x:
                transform.Rotate(new Vector3(1f, 0f, 0f));
                break;
            case RotationAxis.y:
                transform.Rotate(new Vector3(0f, 1f, 0f));
                break;
            case RotationAxis.z:
                transform.Rotate(new Vector3(0f, 0f, 1f));
                break;
            default:
                break;
        }
        
    }
}
