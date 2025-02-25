using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_1_LaserSensorTime : MonoBehaviour
{        
    public bool laser = false;        

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.gameObject.name == "laser")
        {
            laser = true;
        }            
        else
        {
            laser = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        laser = false;        
    }
}
