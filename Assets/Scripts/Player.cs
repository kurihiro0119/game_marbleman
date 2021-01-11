using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BasePlayer
{
    int hp = 3;
    const float shotCurve = 0;
    const float shotSpeed = 10.0f;

    // ビーダマの情報
    float power = 500;
    [SerializeField] GameObject modelMarble;
    GameObject marble;

    float waitingTime = 0.0f;
    bool fireflag = true;

    void FixedUpdate(){
        waitingTime -= 1;
        if(waitingTime <=0){
            fireflag = true;
        }

        if(Input.GetKeyDown("space")){
            if(fireflag){
                shot();
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        Rigidbody2D shotmanagerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

        if(collision.gameObject.tag == "Marble"){
            if(shotmanagerRigidbody.velocity.y < 0){
                hp = hp -1;
            }
        }
        if(hp ==0){
            GameOver();
        }
    }

    void shot(){
        marble = Instantiate(modelMarble, this.transform.position, this.transform.rotation);
        PlayerShotManager shotmanager = marble.GetComponent<PlayerShotManager>();
        shotmanager.Create(shotCurve, shotSpeed);
        waitingTime = 50.0f;
        fireflag = false;
    }
}
