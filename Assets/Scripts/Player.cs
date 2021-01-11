using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BasePlayer
{
    int hp = 3;
    const float defaultShotCurve = 0;
    const float defaultShotSpeed = 10.0f;

    /// <summary>
    /// チャージレベル
    /// </summary>
    protected int ChargeLevel { get; set; }

    // ビーダマの情報
    float power = 500;
    [SerializeField] protected GameObject modelMarble;
    GameObject marble;

    // 発射待機
    float waitingTime = 0.0f;
    // 発射可否
    bool fireflag = true;
    // チャージ時間
    float chargeTime = 0;
    // チャージ状態リセットフラグ
    bool chargeResetFlag = false;
    // チャージ状態リセット時間
    float chargeResetTime = 0;

    void FixedUpdate(){
        waitingTime -= 1;
        if(waitingTime <=0){
            fireflag = true;
        }

        if(Input.GetKeyDown("space")){
            if(fireflag){
                Shot();
            }
        }

        if(Input.GetKey(KeyCode.C)){
            if (fireflag){
                // チャージ
                Charge();
            }
		}

        if(Input.GetKeyUp(KeyCode.C)){
            // チャージをリセットするカウントダウン開始
            chargeResetFlag = true;
        }

        if (chargeResetFlag == true){
            // チャージをリセットするカウントダウン
            chargeResetTime += Time.deltaTime;
        }

        if (chargeResetTime > 1){
            // チャージリセット
            ChargeReset();
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

    virtual protected void Shot(){
        marble = Instantiate(modelMarble, this.transform.position, this.transform.rotation);
        PlayerShotManager shotmanager = marble.GetComponent<PlayerShotManager>();
        shotmanager.Create(defaultShotCurve, defaultShotSpeed);

        // 発射後処理
        AfterShot();
    }

    /// <summary>
    /// 発射後処理
    /// </summary>
    protected void AfterShot(){
        ChargeReset();
        waitingTime = 50.0f;
        fireflag = false;
    }

    /// <summary>
    /// チャージ処理
    /// </summary>
    void Charge(){
        chargeResetFlag = false;
        chargeResetTime = 0;
        chargeTime += Time.deltaTime;

        if (chargeTime > 4)
        {
            // 第２段階
            ChargeLevel = 2;
            Debug.Log("ChargeLevel:" + ChargeLevel);
        }
        else if (chargeTime > 1.5)
        {
            // 第１段階
            ChargeLevel = 1;
            Debug.Log("ChargeLevel:" + ChargeLevel);
        }
    }

    /// <summary>
    /// チャージリセット処理
    /// </summary>
    void ChargeReset(){
        chargeTime = 0;
        ChargeLevel = 0;
        chargeResetFlag = false;
        chargeResetTime = 0;
        Debug.Log("ChargeLevel:" + ChargeLevel);
    }
}
