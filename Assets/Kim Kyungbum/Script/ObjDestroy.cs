using UnityEditor;
using UnityEngine;
using TMPro;

public class ObjDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObj;
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
}
