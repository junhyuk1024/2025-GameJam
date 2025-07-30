using UnityEngine;

public class BaseSingleton<T> : MonoBehaviour where T : MonoBehaviour // T�� MonoBehaviour�� ��ӹް� �־�� ��
{
    private static T instance; // ������ ���� �̱��� ����

    public static T Instance // ������ ���� �̱��� ������ �������� ����Ҷ� ��(�ܺ� ���� ó��, ������ ���� �̱��� �ν��Ͻ� ����,,,)
    {
        get
        {
            if (instance == null) // ���� ������ ���� �̱��� ������ ���� �Ҵ���� �ʾҴٸ� (ó�� �����Ҷ� ������ ������ ����ֱ� ������) 
            {
                // FindObjectOfType<T>()�� ����Ƽ6���� ������ ����
                // ��ü��: FindFirstObjectByType<T>()-���� ó���� ������ T�� ã�� ��ȯ / FindAnyObjectByType<T>()-��ȯ ����� Ư���� �� ������ �� ����
                instance = FindAnyObjectByType<T>(); // ���� ������ T ������Ʈ�� ���� ���� ������Ʈ�� ã��, ã�� �װ� �Ҵ�
                if (instance == null) // ���� ���� ���� T ������Ʈ�� ���� ���� ������Ʈ�� ���ٸ�
                {
                    // ���� ������Ʈ�� ���� �����ϰ�, �װͿ� T ������Ʈ�� �Ҵ�
                    GameObject obj = new(typeof(T).Name);
                    obj.AddComponent<T>();
                    //DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            // (T)this�� �ȵǴ� ����: �� Ŭ������ ��ӹ��� �ڽ� Ŭ����(��: GameManager)�� 'private static GameManager instance'�� �ۼ��Ǳ� ������
            // �ڽ� Ŭ�������� GameManager Ÿ���� instance���ٰ� GameManagerŸ���� �ڽ��� ���� �� ������,
            // �� Singleton Ŭ���� ��ü������ �׷� �ǵ��� ������ 'private static T instance'�� Singleton<T> Ÿ���� �������� �ɷ� ó���ϱ� ������
            // ��������δ� '(T)'�� �ƴ� 'as T'�� ����Ͽ� Ÿ���� T�� instance�� Singleton<T>�� �� ��츦 �������� ��
            instance = this as T;
            //DontDestroyOnLoad(gameObject);

            print(typeof(T).Name + " ���� �Ϸ�");
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}