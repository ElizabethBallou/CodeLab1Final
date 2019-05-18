using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI score; //the text that will hold the score
    private int scoreNumber; //the score number
    private int highScore; //the high score number
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        scoreNumber++;
        score.text = "score " + scoreNumber;
    }
}
