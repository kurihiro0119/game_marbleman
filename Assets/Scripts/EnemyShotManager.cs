using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotManager : ShotManager
{
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player" ){
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Marble" ){
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "BottomWall" ){
            Destroy(this.gameObject);
        }
    }
}
