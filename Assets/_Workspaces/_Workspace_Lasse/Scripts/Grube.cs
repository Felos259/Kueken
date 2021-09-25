using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grube : MonoBehaviour
{

    public Kueken player;

    private void OnTriggerEnter(Collider other)
    {
        player.Die();
    }
}
