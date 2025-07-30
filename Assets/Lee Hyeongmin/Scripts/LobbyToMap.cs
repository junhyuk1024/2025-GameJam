using UnityEngine;

public class LobbyToMap : MonoBehaviour
{
    private bool isUsed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6 && !isUsed)
        {
            // 켜져있는 선율 모두 끄기
            if (AudioManager.Instance.catAudioSource.isPlaying)
            {
                AudioManager.Instance.catAudioSource.Stop();
                print("고양이 소리꺼짐");
            }
            if (AudioManager.Instance.snakeAudioSource.isPlaying) AudioManager.Instance.snakeAudioSource.Stop();
            if (AudioManager.Instance.birdAudioSource.isPlaying) AudioManager.Instance.birdAudioSource.Stop();
            if (AudioManager.Instance.tigerAudioSource.isPlaying) AudioManager.Instance.tigerAudioSource.Stop();
            if (AudioManager.Instance.monkeyAudioSource.isPlaying) AudioManager.Instance.monkeyAudioSource.Stop();

            // 포탈 이름에 따라 BGM 재생
            if (this.gameObject.name == "LobbyToMap1") AudioManager.Instance.PlayMapBGM(AudioManager.Instance.forestAudioClip);
            if (this.gameObject.name == "LobbyToMap2") AudioManager.Instance.PlayMapBGM(AudioManager.Instance.desertAudioClip);
            if (this.gameObject.name == "LobbyToMap3") AudioManager.Instance.PlayMapBGM(AudioManager.Instance.spaceAudioClip);

            // 로비->맵 포탈은 일회용
            Destroy(this);
        }
    }
}
