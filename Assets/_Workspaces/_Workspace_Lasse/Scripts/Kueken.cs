using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kueken : MonoBehaviour
{
    //Varialen, welche in Unity veränderbar sein sollen
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float jumpSpeed = 10;
    [SerializeField] float MaximaleSpringhöhe = 4;
    [SerializeField] float MinimaleSpringhöhe = 2;

    //Höhe am anfang des Sprunges
    float Anfangshöhe;
    //Zwischenspeicherung für den Komponente "Rigidbody"
    Rigidbody2D rigid;
    
    //Gibt die Methode an, welche bei jedem Frame ausgelöst werden soll
    Action stateupdate;
    //Gibt an ob der Boden aktuell berührt wird
    bool touch = false;
    
    //Awake is called before the first frame update
    void Awake(){
        rigid = GetComponent<Rigidbody2D>();
        stateupdate = runningupdate;
    }

    // Update is called once per frame
    void Update(){
        stateupdate();
    }

    //bewegt horizontal und verändert ggf. stateupdate
    void runningupdate()
    {
        //stateupdate ggf. ändern und Anfangshöhe setzen
        if(Input.GetKey(KeyCode.Space)&& touch){
            Anfangshöhe = rigid.position.y;
            stateupdate = jumpingupdate;
        }


        Move();
    }

    //Bewegt Vertikal und Horizontal & verändert ggf. stateupdate(= Mit Sprung aufhören)
    void jumpingupdate() {
        //Vertikale Bewegung
        transform.Translate(0, jumpSpeed * Time.deltaTime, 0);
        bool key = Input.GetKey(KeyCode.Space);

        //ggf. stateupdate verändern (Mit Sprung aufhören)
        if (rigid.position.y > Anfangshöhe + MaximaleSpringhöhe || 
                (!key && rigid.position.y > Anfangshöhe + MinimaleSpringhöhe)){
            stateupdate = runningupdate;
            Anfangshöhe = -100;
        }

 
        Move();
    }

    //Horizontale Bewegung
    void Move(){
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
    }

    //Eventbus um ggf. touch zu verändern
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
