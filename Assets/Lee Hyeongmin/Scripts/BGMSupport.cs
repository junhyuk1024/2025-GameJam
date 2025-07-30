using Unity.VisualScripting;
using UnityEngine;

public class BGMSupport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.layer == 6)
        //{
        //    GameManager.Instance.hasCat = true;
        //    AudioManager.Instance.PlayLobbyBGM();
        //    Destroy(this);
        //}


        // ÂðÀÓ½Ã
        if (other.gameObject.layer == 6)
        {
            GameManager.Instance.hasCat = true;
            GameManager.Instance.hasSnake = true;
            GameManager.Instance.hasBird = true;
            GameManager.Instance.hasTiger = true;
            GameManager.Instance.hasMonkey = true;
            AudioManager.Instance.PlayLobbyBGM();
            Destroy(this);
        }
    }
}
