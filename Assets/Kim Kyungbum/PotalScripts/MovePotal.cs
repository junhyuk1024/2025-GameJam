using UnityEngine;

public class MovePotal : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    public Transform spawnPoint;
    public Transform player;
    bool isEntrance = true;
    void OnTriggerEnter(Collider other)
    {
        if (characterController != null)
        {
            characterController.enabled = false;
        }

        if (isEntrance)
        {
            player.position = spawnPoint.position;
            isEntrance = false;
            Debug.Log(isEntrance);
            Debug.Log("순간이동됨");
        }
        else if(!isEntrance)
        {
            Debug.Log("isEntrance가 false입니다!");
        }

        if (characterController != null)
        {
            characterController.enabled = true;
        }
    }
}
