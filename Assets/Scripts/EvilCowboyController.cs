using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EvilCowboyController : MonoBehaviour
{
    public float walkSpeed = 2.5f;
    public float jumpHeight = 5f;

    public Transform groundCheckTransform;
    public float groundCheckRadius = 0.2f;

    
    public LayerMask mouseAimMask;
    public LayerMask groundMask;

   

    
    
    

    private float inputMovement;
    private Animator animator;
    private bool isGrounded;
    private Camera mainCamera;

    private int FacingSign
    {
        get
        {
            Vector3 perp = Vector3.Cross(transform.forward, Vector3.forward);
            float dir = Vector3.Dot(perp, transform.up);
            return dir > 0f ? -1 : dir < 0f ? 1 : 0;
        }
    }

    void Start()
    {
        
        mainCamera = Camera.main;
    }

    
    void Update()
    {
    }

}
