using UnityEngine;

public class GetPet : MonoBehaviour
{
    public AudioClip petAudioClip;

    private PetMovement petMovement;
    private bool isAdded = false;

    private void Awake()
    {
        petMovement = GetComponent<PetMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        print("¿€µø¡ﬂ");
        if (other.gameObject.layer == 6 && !isAdded)
        {
            isAdded = true;
            AudioManager.Instance.PlayOneSound(petAudioClip);
            GameManager.Instance.PushStack(gameObject);
            petMovement.enabled = true;
            this.enabled = false;
        }
    }
}
