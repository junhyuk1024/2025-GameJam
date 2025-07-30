using UnityEngine;

public class Teleport : MonoBehaviour
{
    public InteractText interactText;
    void Start()
    {
        interactText = GetComponent<InteractText>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.PromptAlpha = 1.0f;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.PromptAlpha = 0.0f;
        }
    }
}
