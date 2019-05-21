using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const string PLAYER_PREF_HIGHSCORE = "highscore";
    private const string FILE_HIGH_SCORE = "MyHighScore.txt";
    public static GameManager instance;

    private AudioSource _audioSource;
    private TeacupPool _teacupPool;
    private TeacupSpawner _teacupSpawner;
    private AudioClip bonkSound;
    private GameObject dishbin;
    public GameObject endButton;
    private int highScore; //the high score number

    public Image life1; //the hearts that represent lives
    public Image life2;
    public Image life3;
    public int lifeCounter;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI overallHighScore;
    public GameObject quitButton;
    public GameObject reloadButton;

    private int scoreNumber; //the score number

    public TextMeshProUGUI scoreText; //the text that will hold the score

    public Image targetTeacupHolder; //the space where the target teacup image will be loaded
    public Image teacupBackground;
    public TextMeshProUGUI toCatchText;

    public TextMeshProUGUI yourScore;

    public int Score //singleton pattern setting the score
    {
        get => scoreNumber;
        set
        {
            scoreNumber = value;
            scoreText.text = "SCORE: " + scoreNumber;
            HighScore = scoreNumber;
        }
    }

    public int HighScore //singleton pattern setting the high score
    {
        get => highScore;
        set
        {
            if (value > highScore)
                highScore = value;
            //PlayerPrefs.SetInt(PLAYER_PREF_HIGHSCORE, highScore);
            //Debug.Log("Application.dataPath: " + Application.dataPath);
            // string fullPathToFile = Application.dataPath + FILE_HIGH_SCORE;
            //File.WriteAllText(fullPathToFile, "Writing to file...");
        }
    }

    // Start is called before the first frame update
    private void Start()
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
        scoreText.text = "SCORE: " + scoreNumber;

        _teacupPool = GameObject.Find("TeacupPool").GetComponent<TeacupPool>(); //get the teacup pool
        _teacupSpawner = GameObject.Find("TeacupPool").GetComponent<TeacupSpawner>(); //get the teacup spawner

        targetTeacupHolder.sprite =
            _teacupPool.SpriteList[Random.Range(0, _teacupPool.SpriteList.Count)]; //set the initial target teacup type
        StartCoroutine("ChangeTargetTeacup"); //activate the coroutine that changes the target teacup image

        lifeCounter = 3; //set the number of lives to 3

        dishbin = GameObject.FindWithTag("Player");
        /*
        string highScoreFileTxt = File.ReadAllText(Application.dataPath + FILE_HIGH_SCORE);
        string[] scoreSplit = highScoreFileTxt.Split(' ');
        HighScore = Int32.Parse(scoreSplit[1]);
        */

        _audioSource = GetComponent<AudioSource>();
        bonkSound = Resources.Load<AudioClip>("Prefabs/bonksound");
        Debug.Log("Got yer bonk sound");
    }

    // Update is called once per frame
    private void Update()
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
                dishbin.gameObject.SetActive(false);
                _teacupSpawner.CancelInvoke("Spawn");
                Debug.Log("No longer invoking");
                break;
        }
    }

    public void IncreaseScore()
    {
        scoreNumber++;
        scoreText.text = "SCORE: " + scoreNumber;
        _audioSource.PlayOneShot(bonkSound);
    }

    private IEnumerator ChangeTargetTeacup()
    {
        yield return new WaitForSeconds(5f);
        targetTeacupHolder.sprite = _teacupPool.SpriteList[Random.Range(0, _teacupPool.SpriteList.Count)];
        StartCoroutine("ChangeTargetTeacup");
    }

    public void LoadScores()
    {
        yourScore.gameObject.SetActive(true);
        overallHighScore.gameObject.SetActive(true);
        reloadButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        Destroy(endButton);

        yourScore.text = "Your Score: " + scoreNumber;
        overallHighScore.text = "High Score: " + HighScore;
    }
}