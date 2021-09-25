using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kueken : MonoBehaviour
{
    //Schnelligkeit
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float jumpSpeed = 10;
    [SerializeField] float MaximaleSpringhöhe = 4;
    [SerializeField] float MinimaleSpringhöhe = 2;

    float Anfangshöhe;
    Rigidbody2D rigid;
    
    Action stateupdate;
    bool touch = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        stateupdate = runningupdate;
    }

    void Update(){
        stateupdate();
    }

    // Update is called once per frame
    void runningupdate()
    {
        //stateupdate ggf. ändern und Anfangshöhe setzen
        if(Input.GetKey(KeyCode.Space)&& touch){
            Anfangshöhe = rigid.position.y;
            stateupdate = jumpingupdate;
        }


        Move();
    }

    //Horizontale Bewegung
    void Move(){
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
    }

    void jumpingupdate() {
        //Horizontale Bewegung
        transform.Translate(0, jumpSpeed * Time.deltaTime, 0);
        bool key = Input.GetKey(KeyCode.Space);

        //ggf. state verändern
        if (rigid.position.y > Anfangshöhe + MaximaleSpringhöhe || 
                (!key && rigid.position.y > Anfangshöhe + MinimaleSpringhöhe)){
            stateupdate = runningupdate;
            Anfangshöhe = -100;
        }

        //Horizontale Bewegung aurufen
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Untergrund unter = other.gameObject.GetComponent<Untergrund>();
            if(unter != null)
                touch = true;  
    }

    private void OnCollisionExit2D(Collision2D other) {
        Untergrund unter = other.gameObject.GetComponent<Untergrund>();
            if(unter != null)
                touch = false;
    }
}
