using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BasePlayer
{
    public const float timeout = 2.0f;
    private float timeElapsed;
    const float shotCurve = 0.5f;
    const float shotSpeed = -4.0f;
    float movementNumber = 0;
    float speed = 1.0f;
    float hp = 3;

    [SerializeField] GameObject modelMarble;
    GameObject marble;

    void Update()
    {
        inputData = Input.GetAxis("Horizontal");
        movementNumber += 1;

        if(movementNumber == 0){
            movingSpeed =0;
        }
        else if( movementNumber > 0){
            movingSpeed = speed;
        }
        else if( movementNumber < 0){
            movingSpeed = -1 * speed;
        }

        rigidbody2D.velocity = new Vector2(movingSpeed, rigidbody2D.velocity.y);

        if(movementNumber > 200){
            movementNumber = -300;
        }
    }

    void FixedUpdate(){
        timeElapsed += Time.deltaTime;
        Debug.Log(timeElapsed);

        if(timeElapsed >= timeout){
            shot();
            timeElapsed = 0.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突判定処理

        Rigidbody2D shotmanagerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

        if (collision.gameObject.tag == "Marble")
        {
            hp = hp - 1;
        }
        if (hp == 0)
        {
            Destroyed();
            GameClear();
        }
    }


    void shot(){
        marble = Instantiate(modelMarble, this.transform.position, this.transform.rotation);
        EnemyShotManager shotmanager = marble.GetComponent<EnemyShotManager>();
        shotmanager.Create(shotCurve, shotSpeed);
    }
}
