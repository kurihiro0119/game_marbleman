using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed = 1000.0F;

    void Update(){
        Debug.Log("inputed");
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(h, v).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
