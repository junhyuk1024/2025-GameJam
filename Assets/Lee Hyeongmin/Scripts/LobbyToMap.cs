using UnityEngine;

public class LobbyToMap : MonoBehaviour
{
    private bool isUsed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6 && !isUsed)
        {
            // �����ִ� ���� ��� ����
            if (AudioManager.Instance.catAudioSource.isPlaying)
            {
                AudioManager.Instance.catAudioSource.Stop();
                print("����� �Ҹ�����");
            }
            if (AudioManager.Instance.snakeAudioSource.isPlaying) AudioManager.Instance.snakeAudioSource.Stop();
            if (AudioManager.Instance.birdAudioSource.isPlaying) AudioManager.Instance.birdAudioSource.Stop();
            if (AudioManager.Instance.tigerAudioSource.isPlaying) AudioManager.Instance.tigerAudioSource.Stop();
            if (AudioManager.Instance.monkeyAudioSource.isPlaying) AudioManager.Instance.monkeyAudioSource.Stop();

            // ��Ż �̸��� ���� BGM ���
            if (this.gameObject.name == "LobbyToMap1") AudioManager.Instance.PlayMapBGM(AudioManager.Instance.forestAudioClip);
            if (this.gameObject.name == "LobbyToMap2") AudioManager.Instance.PlayMapBGM(AudioManager.Instance.desertAudioClip);
            if (this.gameObject.name == "LobbyToMap3") AudioManager.Instance.PlayMapBGM(AudioManager.Instance.spaceAudioClip);

            // �κ�->�� ��Ż�� ��ȸ��
            Destroy(this);
        }
    }
}
