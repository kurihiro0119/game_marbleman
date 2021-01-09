using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    float speed = 4.0f;

    public void Create(){
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0, speed);
    }

}
