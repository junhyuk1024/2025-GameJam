using UnityEngine;

public class GetPet : MonoBehaviour
{
    private PetMovement petMovement;
    private bool isAdded = false;

    private void Awake()
    {
        petMovement = GetComponent<PetMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 6 && !isAdded)
        {
            isAdded = true;
            GameManager.Instance.PushStack(gameObject);
            petMovement.enabled = true;
            this.enabled = false;
        }
    }
}
