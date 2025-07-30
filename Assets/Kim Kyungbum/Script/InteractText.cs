using UnityEngine;
using TMPro;

public class InteractText : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    public Transform spawnPoint;
    public TextMeshProUGUI promptText;
    private ObjDestroy targetDestroyScript;
    public Transform player;

    public float PromptAlpha
    {
        get => promptText.color.a;
        set
        {
            Color newColor = promptText.color; // 복사본 가져오기
            newColor.a = value;                 // 복사본 수정
            promptText.color = newColor;       // 복사본을 다시 대입
        }
    }

    void Start()
    {
        targetDestroyScript = GetComponent<ObjDestroy>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("켜짐");
            promptText.color = new Color32(255, 255, 255, 255);
            Debug.Log(promptText.color.a);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("꺼짐");
            promptText.color = new Color32(255, 255, 255, 0);
            Debug.Log(promptText.color.a);
        }
    }
    void Update()
    {
        if (promptText.color.a != 0)
        {
            string name = promptText.gameObject.name;

            if (name == "TextPickup")
            {
                targetDestroyScript.destroyObject();
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            teleportPlayer();
        }
    }

    void teleportPlayer()
    {
        if (characterController != null)
        {
            characterController.enabled = false;
        }

        PromptAlpha = 0.0f;
        player.position = spawnPoint.position;
        Debug.Log("순간이동됨");

        if (characterController != null)
        {
            characterController.enabled = true;
        }
    }
}
