using Nvp.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Kueken : MonoBehaviour
{
    //Varialen, welche in Unity veränderbar sein sollen
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float jumpSpeed = 10;
    [SerializeField] float MaximaleSpringhöhe = 4;
    [SerializeField] float MinimaleSpringhöhe = 2;

    public GameObject message;
    public Animator animator;
    public GameManager game;
    //Höhe am anfang des Sprunges
    public float Anfangshöhe;
    //Zwischenspeicherungen für Komponenten
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Transform transformer;
    BoxCollider2D collider;

    //Gibt die Methode an, welche bei jedem Frame ausgelöst werden soll
    Action stateupdate;
    //Gibt die Methode an, wen den Sound "Gehen" ausgelöst werden soll
    Action Soundgehen;
    //Gibt an ob der Boden aktuell berührt wird
    bool touch = false;
    //Gibt an ob das Küken tod ist
    bool dead = false;
    //Gibt an der Körper reseten werden soll
    bool reset = false;
    
    //Awake is called before the first frame update
    void Awake(){
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        transformer = GetComponent<Transform>();
        collider = GetComponent<BoxCollider2D>();
        stateupdate = runningupdate;
    }

    // Update is called once per frame
    void Update(){
        if (reset){
            reset = false;
            Reset();
        }

        if (dead)
            return;
        stateupdate();

        if (rigid.position.y < -7)
            Die();
    }

    //bewegt horizontal und verändert ggf. stateupdate
    void runningupdate()
    {
        //stateupdate ggf. ändern und Anfangshöhe setzen
        if(Input.GetKey(KeyCode.Space)&& touch){
            Anfangshöhe = rigid.position.y;
            EventManager.Invoke("OnPlayerJump", null, null);
            animator.SetBool("Up", true);
            stateupdate = jumpingupdate;
        }

        if ((Input.GetKey("a") || Input.GetKey("d") || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && touch)
            EventManager.Invoke("OnPlayerGehen", null, null);

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
        animator.SetBool("Down", false);

        //Fals Boden berührt wird
        Untergrund unter = other.gameObject.GetComponent<Untergrund>();
        if (unter != null)
            touch = true;
        else{
            Käfer käfer = other.gameObject.GetComponent<Käfer>();
            if (käfer == null)
                return;
            if(other.contacts[0].normal.x != 0) 
                Die();
        }
        
    }

    private void OnCollisionExit2D(Collision2D other) {
        Untergrund unter = other.gameObject.GetComponent<Untergrund>();
        if(unter != null)
            touch = false;
        if (stateupdate != jumpingupdate && !touch &&!dead)
            animator.SetBool("Down", true);
    }

    public void Die(){
        dead = true;
        rigid.simulated = false;
        collider.enabled = false;

        animator.SetBool("Dead", true);
        showDeadMessage();
        EventManager.Invoke("OnPlayerDied", null, null);

        new Thread(WaitAndReset).Start();
    }
    private void WaitAndReset()
    {
        Thread.Sleep(3000);
        reset = true;
    }
    private void Reset()
    {
        dead = false;

        animator.SetBool("Dead", false);
        transformer.position = new Vector3(-52 - 2, 0);

        collider.enabled = true;
        rigid.simulated = true;

        
        disposeDeadMessage();
    }

    //Todesnachricht zeigen
    private void showDeadMessage(){
        var pos = message.GetComponent<Transform>().position;
        message.GetComponent<Transform>().position = new Vector3(rigid.position.x - 15, pos.y, 20);
    }

    //Todesnachricht verschwinden lassen
    private void disposeDeadMessage() {
        var pos = message.GetComponent<Transform>().position;
        message.GetComponent<Transform>().position = new Vector3(-100, pos.y, -20);
    }
    
    
}
