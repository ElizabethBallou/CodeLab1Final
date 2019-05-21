using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private GameObject _gameManager;

    // Start is called before the first frame update
    private void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager");
        Debug.Log("Found the game manager!");
    }

    public void ReloadScene()
    {
        Destroy(_gameManager);
        SceneManager.LoadScene("MainScene");
    }
}