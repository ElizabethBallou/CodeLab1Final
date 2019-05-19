using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI score; //the text that will hold the score
    private int scoreNumber; //the score number
    private int highScore; //the high score number

    public Image life1; //the hearts that represent lives
    public Image life2;
    public Image life3;
    public float minY = -7;

    public Image targetTeacupHolder;
    private int targetTeacupType;

    TeacupPool _teacupPool;

    
    // Start is called before the first frame update
    void Start()
    {
        //create GameManger singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        scoreNumber = 0;
        score = GameObject.FindWithTag("score").GetComponent<TextMeshProUGUI>();
        score.text = "score: " + scoreNumber;
        
        _teacupPool = GameObject.Find("TeacupPool").GetComponent<TeacupPool>(); //get the teacup pool
        targetTeacupHolder.sprite = _teacupPool.SpriteList[Random.Range(0, _teacupPool.SpriteList.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ChangeTargetTeacup(5f));
    }

    public void IncreaseScore()
    {
        scoreNumber++;
        score.text = "score " + scoreNumber;
    }

    IEnumerator ChangeTargetTeacup(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        targetTeacupHolder.sprite = _teacupPool.SpriteList[Random.Range(0, _teacupPool.SpriteList.Count)];
    }
}
