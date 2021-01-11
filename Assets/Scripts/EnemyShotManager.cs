using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotManager : ShotManager
{
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player" ){
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Marble" ){
            Destroy(this.gameObject);
        }
    }
}
