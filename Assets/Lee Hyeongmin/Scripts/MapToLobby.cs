using UnityEngine;

public class MapToLobby : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            AudioManager.Instance.BGMAudioSource.Stop();
            AudioManager.Instance.PlayLobbyBGM();
        }
    }
}
