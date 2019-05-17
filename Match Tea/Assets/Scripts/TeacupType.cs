using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacupType : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public List<Sprite> SpriteList;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = SpriteList[Random.Range(0, SpriteList.Count)];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
