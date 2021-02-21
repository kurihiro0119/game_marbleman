using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShotManager : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    public void Create(float xspeed, float yspeed){
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(xspeed, yspeed);
    }

}
