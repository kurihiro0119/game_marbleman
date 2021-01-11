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
        // StartCoroutine(DisableIsTrigger(0.2f, () =>
        // {
        //     BoxCollider2D collider = GetComponent<BoxCollider2D>();
        //     collider.isTrigger = false;
        // }));
    }

    // private IEnumerator DisableIsTrigger(float waitTime, Action action){
    //     yield return new WaitForSeconds(waitTime);
    //     action();
    // }

}
