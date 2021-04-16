using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{

    public float speed = 1f;
    private Rigidbody enemyRb;
    private GameObject player;
    public GameObject bulletPrefab;
    public float damageAmount = 10f;    // just a default value
    public float hitPoints = 100f;        // just a default value
    private float recoilTimer;
    private Animator anim;
    public Transform muzzleTransform;
    public Transform rightLowerArm;
    public Transform rightHand;
    public float recoilDuration = 0.25f;
    public AnimationCurve recoilCurve;
    public float recoilMaxRotation = 45f;
    public Transform targetTransform;
    private Rigidbody rbody;
    float timer = 0f;



    public void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (player.transform.position.y >= transform.position.y)
        {
            transform.LookAt(player.transform);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            anim.SetIKPosition(AvatarIKGoal.RightHand, player.transform.position);
            if(timer <= 0.3f){
                timer += Time.deltaTime;
            }
            else{
                timer = 0;
                Fire();
            }
            
        }
        ResetZ();
        
        if (System.Math.Abs(transform.position.y) > 50) { Destroy(gameObject); }
        

        //waddle around
        //wait for player
        //attack when player nearby
    }

    private void Fire()
    {
        recoilTimer = Time.time;
        var go = Instantiate(bulletPrefab);
        var bullet = go.GetComponent<PlayerBullet>();
        Vector3 fireLocation = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.95f,
            gameObject.transform.position.z);
        bullet.Fire(fireLocation, gameObject.transform.rotation.eulerAngles, gameObject.layer);
        //go.transform.position = go.transform.position + speed * transform.forward;
        //go.transform.Translate(Vector3.forward * Time.deltaTime);
        Debug.Log("firing bullet");
    }
    
    
    private void LateUpdate()
    {
        // Recoil Animation
        if (recoilTimer < 0)
        {
            return;
        }

        float curveTime = (Time.time - recoilTimer) / recoilDuration;
        if (curveTime > 1f)
        {
            recoilTimer = -1;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }
        Debug.Log(other.gameObject.tag);
    }

    public void ResetZ()
    {
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;
    }
}



