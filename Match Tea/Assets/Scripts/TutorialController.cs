using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public GameObject teacups;
    public GameObject tutorialButton;
    public GameObject playButton;
    public TextMeshProUGUI title;
    public TextMeshProUGUI explainerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TutorialClick()
    {
        teacups.gameObject.SetActive(false);
        title.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
        explainerText.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
