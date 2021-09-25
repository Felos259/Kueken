using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kueken : MonoBehaviour
{
    //Schnelligkeit
    [SerializeField] float moveSpeed = 10;
    bool touch = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey("a")){
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            float jump = Input.GetAxis("Jump");

            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);

            if(touch)
                transform.Translate(0,jump*Time.deltaTime*100,0);
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
