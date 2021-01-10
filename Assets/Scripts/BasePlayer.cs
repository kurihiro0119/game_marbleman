using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayer : MonoBehaviour
{
    // 操作速度
    float movingSpeed;

    float speed = 3.0f;
    //キーボードの入力情報
    float inputData;

    //操作用オブジェクト
    Rigidbody2D rigidbody2D;

    [SerializeField] GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        inputData = Input.GetAxis("Horizontal");

        if(inputData == 0){
            movingSpeed =0;
        }
        else if( inputData > 0){
            movingSpeed = speed;
        }
        else if( inputData < 0){
            movingSpeed = -1 * speed;
        }

        rigidbody2D.velocity = new Vector2(movingSpeed, rigidbody2D.velocity.y);
    }

        void FixedUpdate(){

    }

    public void GameOver(){
        gameManager.GameOver();
    }

    void shot(){
        // marble = Instantiate(modelMarble, this.transform.position, this.transform.rotation);
        // ShotManager shotmanager = marble.GetComponent<ShotManager>();
        // shotmanager.Create();
    }
}
