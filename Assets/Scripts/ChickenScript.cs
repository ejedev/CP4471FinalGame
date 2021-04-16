using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenScript : MonoBehaviour
{
    private GameObject player;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ResetZ();
        if (System.Math.Abs(transform.position.y) > 50) { Destroy(gameObject); }
        
        transform.LookAt(player.transform);
        transform.position += transform.forward * Time.deltaTime;
        
    }
    
    public void ResetZ()
    {
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PlayerBullet") || other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        Debug.Log(other.gameObject.tag);
    }
}
