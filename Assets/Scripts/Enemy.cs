using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BasePlayer
{
    float speed = 10.0f;

        
    void FixedUpdate(){
        Debug.Log(speed);
    }
}
