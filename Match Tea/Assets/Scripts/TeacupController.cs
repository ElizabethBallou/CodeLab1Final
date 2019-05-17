using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacupController : MonoBehaviour
{
    public float startY = 7;
    public float minY = -7;
    public float xRange = 7;
    TeacupPool teacupPool;
    private SpriteRenderer _spriteRenderer;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        teacupPool = GameObject.Find("PoolHolder").GetComponent<TeacupPool>(); //get the box pool
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY) //if the box has fallen to far
        {
            Reset(); //reset the object
        }
    }

    public void Reset()
    {
        //Reset the position to above the screen and a random x position between the -xRange and xRange
        transform.position = new Vector3(Random.Range(-xRange, xRange), startY, transform.position.z); //reset the position
        rb.velocity = Vector3.zero; //reset the velocity
        _spriteRenderer.sprite = teacupPool.SpriteList[Random.Range(0, teacupPool.SpriteList.Count)];
        gameObject.SetActive(false); //turn off the object
        teacupPool.teacupList.Add(gameObject); //add it to the box pool
    }
}
