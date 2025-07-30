using UnityEngine;

public class DynamicCarpet : MonoBehaviour
{
    public MonsterCtrl monster;

    private Renderer carpetRenderer;

    // �ӽ� �Ҹ� ���
    private AudioSource audioSource;
    public AudioClip audioClip;
    private bool oneShot = false;

    private void Awake()
    {
        carpetRenderer = GetComponent<Renderer>();
        carpetRenderer.enabled = false;

        //audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            // ���� ������ �� ����� ���
            carpetRenderer.enabled = true;

            if (oneShot == false)
            {
                //audioSource.PlayOneShot(audioClip);
                AudioManager.Instance.PlayOneSound(audioClip);
                oneShot = true;
            }

            // ���Ϳ��� �������� ������
            monster.HeardSound(transform.position);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            print("���");
            carpetRenderer.enabled = false;
            oneShot = false;
        }
    }
}
