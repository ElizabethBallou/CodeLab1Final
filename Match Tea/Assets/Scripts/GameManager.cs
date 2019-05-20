using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    TeacupPool _teacupPool;
    TeacupSpawner _teacupSpawner;

    public TextMeshProUGUI scoreText; //the text that will hold the score
    public TextMeshProUGUI toCatchText;
    public TextMeshProUGUI lifeText;
    public Button endButton;
    
    private int scoreNumber; //the score number
    private int highScore; //the high score number

    public Image life1; //the hearts that represent lives
    public Image life2;
    public Image life3;
    public int lifeCounter;
    
    public Image targetTeacupHolder; //the space where the target teacup image will be loaded
    public Image teacupBackground;
    
    
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
        scoreText = GameObject.FindWithTag("score").GetComponent<TextMeshProUGUI>();
        scoreText.text = "score: " + scoreNumber;
        
        _teacupPool = GameObject.Find("TeacupPool").GetComponent<TeacupPool>(); //get the teacup pool
        _teacupSpawner = GameObject.Find("TeacupPool").GetComponent<TeacupSpawner>(); //get the teacup spawner

        targetTeacupHolder.sprite = _teacupPool.SpriteList[Random.Range(0, _teacupPool.SpriteList.Count)]; //set the initial target teacup type
        StartCoroutine("ChangeTargetTeacup"); //activate the coroutine that changes the target teacup image

        lifeCounter = 3; //set the number of lives to 3
    }

    // Update is called once per frame
    void Update()
    {
        switch (lifeCounter)
        {
            case 3:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                break;
            case 2:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(false);
                break;
            case 1:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                break;
            case 0:
                life1.gameObject.SetActive(false);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                targetTeacupHolder.gameObject.SetActive(false);
                teacupBackground.gameObject.SetActive(false);
                scoreText.gameObject.SetActive(false);
                lifeText.gameObject.SetActive(false);
                toCatchText.gameObject.SetActive(false);
                endButton.gameObject.SetActive(true);
                GameObject Player = GameObject.FindWithTag("Player");
                Player.gameObject.SetActive(false);
                _teacupSpawner.CancelInvoke("Spawn");
                Debug.Log("No longer invoking");
                break;
        }
    }

    public void IncreaseScore()
    {
        scoreNumber++;
        scoreText.text = "score " + scoreNumber;
    }

    IEnumerator ChangeTargetTeacup()
    {
        yield return new WaitForSeconds(5f);
        targetTeacupHolder.sprite = _teacupPool.SpriteList[Random.Range(0, _teacupPool.SpriteList.Count)];
        StartCoroutine("ChangeTargetTeacup");
    }

    public void LoadScoreList()
    {
        SceneManager.LoadScene("ScoreList");
    }
}
