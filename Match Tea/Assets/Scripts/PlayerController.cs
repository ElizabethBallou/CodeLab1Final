using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private GameManager _gameManager;
    private TeacupPool _teacupPool2;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); //get the game manager
        _teacupPool2 = GameObject.Find("TeacupPool").GetComponent<TeacupPool>(); //get the teacup pool

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
    
   //a function that destroys teacups that match the target image
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("teacup"))
        {
            Debug.Log("A teacup hit the bin!"); //this checks to see whether ANY teacup hit the bin
            
            if (other.gameObject.GetComponent<SpriteRenderer>().sprite ==
                _gameManager.targetTeacupHolder.GetComponent<Image>().sprite) //if the source sprite on the object that has been collided with matches the source sprite on the target image
            {
                Debug.Log("The target kind of teacup hit the bin!");
                Destroy(other.gameObject);
                GameManager.instance.IncreaseScore();
            }

            if (other.gameObject.GetComponent<SpriteRenderer>().sprite !=
                _gameManager.targetTeacupHolder.GetComponent<Image>().sprite)
            {
                Debug.Log("Aww, you messed up");
                Destroy(other.gameObject);
                _gameManager.lifeCounter--;
            }
        }
    }
}
