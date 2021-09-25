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

    public GameObject message;
    public Soundboard sound;
    public Animator animator;

    //Höhe am anfang des Sprunges
    float Anfangshöhe;
    //Zwischenspeicherungen für Komponenten
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Transform transformer;
    
    //Gibt die Methode an, welche bei jedem Frame ausgelöst werden soll
    Action stateupdate;
    //Gibt an ob der Boden aktuell berührt wird
    bool touch = false;
    
    //Awake is called before the first frame update
    void Awake(){
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        transformer = GetComponent<Transform>();
        stateupdate = runningupdate;
    }

    // Update is called once per frame
    void Update(){
        stateupdate();

        if (rigid.position.y < -5)
            Die();
    }

    //bewegt horizontal und verändert ggf. stateupdate
    void runningupdate()
    {
        //stateupdate ggf. ändern und Anfangshöhe setzen
        if(Input.GetKey(KeyCode.Space)&& touch){
            Anfangshöhe = rigid.position.y;
            animator.SetBool("Up", true);
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
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
            Anfangshöhe = -100;
        }

 
        Move();
    }

    //Horizontale Bewegung
    void Move(){
        float horizontalInput = Input.GetAxis("Horizontal") * moveSpeed;
        transform.Translate(new Vector3(horizontalInput, 0, 0)  * Time.deltaTime);

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if (horizontalInput < 0)
            sprite.flipX = true;
        else
            sprite.flipX = false;
    }

    //Eventbus um ggf. touch zu verändern
    private void OnCollisionEnter2D(Collision2D other) {
        Untergrund unter = other.gameObject.GetComponent<Untergrund>();
            if(unter != null && other.contacts[0].normal.y>0.5)
                touch = true;
        animator.SetBool("Down", false);
    }

    private void OnCollisionExit2D(Collision2D other) {
        Untergrund unter = other.gameObject.GetComponent<Untergrund>();
            if(unter != null)
                touch = false;
    }

    public void Die(){
        var pos = message.GetComponent<Transform>().position;
        message.GetComponent<Transform>().position = new Vector3(rigid.position.x - 15, pos.y, 20);
        sound.SoundSterben();
    }
}
