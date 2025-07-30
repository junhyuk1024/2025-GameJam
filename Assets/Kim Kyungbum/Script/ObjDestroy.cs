using UnityEditor;
using UnityEngine;

public class ObjDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObj;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private CharacterController characterController; // 잡았다 문제의근원
    
    [SerializeField]
    public Transform spawnPoint;

    public InteractText interactText;

    

    void Start()
    {
        interactText = GetComponent<InteractText>();
    }
    public void destroyObject()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(targetObj);
            interactText.PromptAlpha = 0.0f;
            Debug.Log("promptText 투명도: " + interactText.PromptAlpha);
            Debug.Log("오브젝트 삭제됨");
        }
    }
    public void teleport()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (characterController != null)
            {
                characterController.enabled = false;
            }
            interactText.PromptAlpha = 0.0f;
            player.position = spawnPoint.position;
            if (characterController != null)
            {
                characterController.enabled = true;
            }
            Debug.Log("순간이동됨");
        }

    }
}
