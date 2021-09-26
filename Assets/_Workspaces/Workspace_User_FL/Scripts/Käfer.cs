using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Käfer : MonoBehaviour
{

    [SerializeField] PolygonCollider2D _polygonCollider;
    [SerializeField] BoxCollider2D _boxCollider;
    [SerializeField] Sprite _deadSprite;
    [SerializeField] SpriteRenderer _renderer;
    bool _hasDied;
    SpriteRenderer sprite;
    [SerializeField] ParticleSystem _particleSystem;
    public int speed;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //bewegt sich für die Zeit, die der letzte
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (ShouldDieFromCollosion(collision) == true)
        {
            Die();
        }

        if (ShouldTurnLeft(collision) == true)
        {

        }

    }

    

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision");
        speed*= -1;
        
    }

    bool ShouldDieFromCollosion(Collision2D collision)
    {
        if (_hasDied == true)
        {
            return false;
        }

        //prüft, ob das Monster von oben berührt wird; liefert bei Berührung true
        if (collision.contacts[0].normal.y < -0.5)
        {
            return true;
        }

        return false;
    }

    bool ShouldTurnLeft(Collision2D collision)
    {
        
        TriggerLeft left = collision.gameObject.GetComponent<TriggerLeft>();
        if (left != null)
        {
            return true;
        }
        return false;
    }

    bool ShouldTurnRight(Collision2D collision)
    {
        TriggerRight right = collision.gameObject.GetComponent<TriggerRight>();
        if (right != null)
        {
            return true;
        }
        return false;
    }

    void Die()
    {
        _hasDied = true;
        if(_polygonCollider.enabled)_polygonCollider.enabled = false;
        if(_boxCollider.enabled)_boxCollider.enabled = false;
        _renderer.enabled = false;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();
        Destroy(this.transform.parent.parent.gameObject, 1.5f);
        //_polygonCollider.enabled = false;
        //gameObject.SetActive(false);
    }
}
