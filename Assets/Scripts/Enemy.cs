using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10f;
    private Rigidbody enemyRb;
    private GameObject player;

    public float damageAmount = 10f;    // just a default value
    public float hitPoints = 100f;        // just a default value
    
    public Animator anim;

    public void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        ResetZ();
        
        if (Math.Abs(transform.position.y) > 50) { Destroy(gameObject); }
        

        //waddle around
        //wait for player
        //attack when player nearby
    }

    public void ResetZ()
    {
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;
    }
}

