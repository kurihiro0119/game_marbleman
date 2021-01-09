using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BasePlayer
{
    float hp = 100.0f;

    // ビーダマの情報
    float power = 500;
    [SerializeField] GameObject modelMarble;
    GameObject marble;

    void FixedUpdate(){
        if(Input.GetKeyDown("space")){
            shot();
        }

    }

    void shot(){
        marble = Instantiate(modelMarble, this.transform.position, this.transform.rotation);
        ShotManager shotmanager = marble.GetComponent<ShotManager>();
        shotmanager.Create();
        Debug.Log("shot");
    }
}
