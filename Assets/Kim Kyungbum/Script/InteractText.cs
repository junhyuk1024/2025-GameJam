using UnityEngine;
using TMPro;

public class InteractText : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    private ObjDestroy targetDestroyScript;

    public float PromptAlpha
    {
        get => promptText.color.a;
        set
        {
            Color newColor = promptText.color; // 복사본 가져오기
            newColor.a = value;          // 복사본 수정
            promptText.color = newColor;       // 복사본을 다시 대입
        }
    }

    void Start()
    {
        targetDestroyScript = GetComponent<ObjDestroy>();
    }
    void Update()
    {
        if (promptText.color.a != 0)
        {
            targetDestroyScript.destroyObject();
        }
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
}
