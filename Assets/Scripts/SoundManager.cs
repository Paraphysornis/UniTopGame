using UnityEngine;

public enum BGMType
{
    None, Title, InGame, InBoss
}

public enum SEType
{
    GameClear, GameOver, Shoot
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip meGameClear, meGameOver, seShoot, bgmInTitle, bgmInGame, bgmInBoss;
    public static SoundManager soundManager;
    public static BGMType playingBGM = BGMType.None;
    AudioSource audio;

    private void Awake()
    {
        if (soundManager == null)
        {
            soundManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.loop = true;
    }

    public void PlayBgm(BGMType type)
    {
        if (type != playingBGM)
        {
            playingBGM = type;

            if (type == BGMType.Title)
            {
                audio.clip = bgmInTitle;
            }
            else if (type == BGMType.InGame)
            {
                audio.clip = bgmInGame;
            }
            else if (type == BGMType.InBoss)
            {
                audio.clip = bgmInBoss;
            }

            audio.Play();
        }
    }

    public void StopBgm()
    {
        audio.Stop();
        playingBGM = BGMType.None;
    }

    public void SEPlay(SEType type)
    {
        if (type == SEType.GameClear)
        {
            audio.PlayOneShot(meGameClear);
        }
        else if (type == SEType.GameOver)
        {
            audio.PlayOneShot(meGameOver);
        }
        else if (type == SEType.Shoot)
        {
            audio.PlayOneShot(seShoot);
        }
    }
}
