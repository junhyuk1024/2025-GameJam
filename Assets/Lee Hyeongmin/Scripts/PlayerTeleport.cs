using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public Transform arrivalPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            print("Æ÷Å»ÀÌµ¿");
            other.transform.position = arrivalPoint.position;
        }
    }
}
