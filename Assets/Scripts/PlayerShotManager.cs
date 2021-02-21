using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotManager : ShotManager
{

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Enemy" ){
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Marble" ){
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "TopWall" ){
            Destroy(this.gameObject);
        }
        
    }
}
