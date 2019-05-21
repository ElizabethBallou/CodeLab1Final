using UnityEngine;

public class ThemeMusicPlayer : MonoBehaviour
{
    public static ThemeMusicPlayer instance;

    private AudioSource _audioSource;

    private AudioClip themeMusic;

    // Start is called before the first frame update
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _audioSource = GetComponent<AudioSource>();
        themeMusic = Resources.Load<AudioClip>("Prefabs/thememusic");
        _audioSource.clip = themeMusic;
        _audioSource.Play();
        _audioSource.loop = true;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}