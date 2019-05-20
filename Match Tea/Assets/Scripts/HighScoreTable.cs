using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class HighScoreTable : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    public float TemplateHeight;

    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        
        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry{score = 24, name = "EPB"},
            new HighScoreEntry{score = 28, name = "EPB"},
            new HighScoreEntry{score = 18, name = "EPB"},
            new HighScoreEntry{score = 15, name = "EPB"},
            new HighScoreEntry{score = 12, name = "EPB"},

        };

        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -TemplateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "th"; break;
                
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
        }

        entryTransform.Find("exampleposition").GetComponent<TextMeshProUGUI>().text = rankString;

        int score = highScoreEntry.score;
            
        entryTransform.Find("examplename").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highScoreEntry.name;
            
        entryTransform.Find("examplescore").GetComponent<TextMeshProUGUI>().text = name;
        
        transformList.Add(entryTransform);

    }

    private class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
