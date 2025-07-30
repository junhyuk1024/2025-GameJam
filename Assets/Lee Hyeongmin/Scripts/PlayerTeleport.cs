using System.Collections;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public Transform arrivalPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            print("Æ÷Å»ÀÌµ¿");
            CharacterController characterController = other.GetComponent<CharacterController>();
            characterController.enabled = false;
            other.transform.position = arrivalPoint.position + arrivalPoint.forward * 2f;
            //other.transform.rotation = arrivalPoint.rotation;
            other.transform.rotation = Quaternion.LookRotation(arrivalPoint.forward, Vector3.up);
            characterController.enabled = true;
        }
    }

    //private IEnumerator Teleport(Vector3 pos)
    //{
    //    characterController.enabled = false;

    //}
}
