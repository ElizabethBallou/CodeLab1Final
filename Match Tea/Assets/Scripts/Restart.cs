using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private GameObject _audioManager;
    private GameObject _gameManager;

    // Start is called before the first frame update
    private void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager");
        Debug.Log("Found the game manager!");
        _audioManager = GameObject.FindWithTag("AudioManager");
        Debug.Log("Found the audio manager!");
    }

    public void ReloadScene()
    {
        Destroy(_gameManager);
        SceneManager.LoadScene("MainScene");
    }

    public void RestartGame()
    {
        Destroy(_gameManager);
        Destroy(_audioManager);
        SceneManager.LoadScene("IntroScene");
    }
}