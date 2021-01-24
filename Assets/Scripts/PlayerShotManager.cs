using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotManager : ShotManager
{

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Enemy" ){
            DestroyObject();
        }

        if(collision.gameObject.tag == "Marble" ){
            DestroyObject();
        }
    }
}
