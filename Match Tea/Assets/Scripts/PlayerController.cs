using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newVelocity = new Vector3();
        
        if (Input.GetKey(KeyCode.A)) //move left
        {
            newVelocity.x += -speed;
        }

        if (Input.GetKey(KeyCode.D)) //move right
        {
            newVelocity.x += speed;
        }

        rb.velocity = newVelocity;
    }
    
   //a function that destroys any teacups that collide with the bin
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("teacup"))
        {
            Debug.Log("A teacup hit the bin!");
            Destroy(other.gameObject);
            GameManager.instance.IncreaseScore();
        }
    }
}
