using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject puppet;
    public GameObject trigger1;
    public GameObject trigger2;

    //Variablen für den Tod
    [SerializeField] Sprite _deadSprite;
    bool _hasDied;
    [SerializeField] ParticleSystem _particleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        puppet.transform.Translate(Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCollosion(collision) == true)
        {
            Die();
        }
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

    void Die()
    {
        _hasDied = true;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();
        //gameObject.SetActive(false);
    }

}

