using UnityEngine;

public class AudioManager : BaseSingleton<AudioManager>
{
    public AudioSource catAudioSource;
    public AudioSource snakeAudioSource;
    public AudioSource birdAudioSource;
    public AudioSource tigerAudioSource;
    public AudioSource monkeyAudioSource;
    public bool PlayingLobbyBGM;

    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOneSound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void PlayLobbyBGM()
    {
        if (GameManager.Instance.hasCat) catAudioSource.Play();
        if (GameManager.Instance.hasSnake) snakeAudioSource.Play();
        if (GameManager.Instance.hasBird) birdAudioSource.Play();
        if (GameManager.Instance.hasTiger) tigerAudioSource.Play();
        if (GameManager.Instance.hasMonkey) monkeyAudioSource.Play();
    }
}
