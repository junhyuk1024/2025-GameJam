using UnityEngine;

public class AudioManager : BaseSingleton<AudioManager>
{
    // 동물 선율
    public AudioSource catAudioSource;
    public AudioSource snakeAudioSource;
    public AudioSource birdAudioSource;
    public AudioSource tigerAudioSource;
    public AudioSource monkeyAudioSource;

    // 맵 지형 브금은 하나로 관리
    public AudioSource BGMAudioSource;

    // 배경 브금 클립
    public AudioClip forestAudioClip;
    public AudioClip desertAudioClip;
    public AudioClip spaceAudioClip;

    public bool PlayingLobbyBGM;

    private AudioSource ManagerAudioSource;

    protected override void Awake()
    {
        base.Awake();
        ManagerAudioSource = GetComponent<AudioSource>();
    }

    public void PlayOneSound(AudioClip audioClip)
    {
        ManagerAudioSource.PlayOneShot(audioClip);
    }

    public void PlayLobbyBGM()
    {
        if (GameManager.Instance.hasCat) catAudioSource.Play();
        if (GameManager.Instance.hasSnake) snakeAudioSource.Play();
        if (GameManager.Instance.hasBird) birdAudioSource.Play();
        if (GameManager.Instance.hasTiger) tigerAudioSource.Play();
        if (GameManager.Instance.hasMonkey) monkeyAudioSource.Play();
    }

    public void PlayMapBGM(AudioClip audioClip)
    {
        BGMAudioSource.clip = audioClip;
        BGMAudioSource.Play();
    }
}
