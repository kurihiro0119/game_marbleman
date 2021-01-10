using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BasePlayer
{
    int hp = 3;

    // ビーダマの情報
    float power = 500;
    [SerializeField] GameObject modelMarble;
    GameObject marble;

    void FixedUpdate(){
        if(Input.GetKeyDown("space")){
            shot();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Marble"){
            hp = hp -1;
        }
        if(hp ==0){
            GameOver();
        }
    }

    void shot(){
        marble = Instantiate(modelMarble, this.transform.position, this.transform.rotation);
        ShotManager shotmanager = marble.GetComponent<ShotManager>();
        shotmanager.Create();
        Debug.Log("shot");
    }
}
