using UnityEngine;

public class AudioManager : BaseSingleton<AudioManager>
{
    // ���� ����
    public AudioSource catAudioSource;
    public AudioSource snakeAudioSource;
    public AudioSource birdAudioSource;
    public AudioSource tigerAudioSource;
    public AudioSource monkeyAudioSource;

    // �� ���� ����� �ϳ��� ����
    public AudioSource BGMAudioSource;

    // ��� ��� Ŭ��
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
