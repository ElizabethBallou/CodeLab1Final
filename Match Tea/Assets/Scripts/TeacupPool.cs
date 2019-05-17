using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacupPool : MonoBehaviour
{
    public List<GameObject> teacupList;
    private SpriteRenderer _spriteRenderer;
    public List<Sprite> SpriteList;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public GameObject GetTeacup()
        {
            GameObject result = null;
        
            if (teacupList.Count > 0) //Do we have any boxes to recycle?
            {
                //get a box out of the list and recycle it
                result = teacupList[0];
                teacupList.Remove(result);
                result.SetActive(true);
            }
            else  //No?
            {
                //make a new box
                result = Instantiate(Resources.Load<GameObject>("Prefabs/teacuporiginal")); //init prefab from resources
                _spriteRenderer = result.GetComponent<SpriteRenderer>();
                _spriteRenderer.sprite = SpriteList[Random.Range(0, SpriteList.Count)];

            }

            return result;
        }
}
