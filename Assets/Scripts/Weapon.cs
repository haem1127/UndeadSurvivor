using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // ���� id, ������ id, ������, ����, �ӵ� ���� ����
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    private void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = -150;
                Batch();
                break;
            default:
                break;
        }
    }

    void Batch()
    {
        for(int index = 0; index < count; index++)
        {
            // ������ ������Ʈ�� Transform�� ���������� ����
            Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
            // parent �Ӽ��� ���� �θ� ����
            bullet.parent = transform;
            // Bullet ������Ʈ �����Ͽ� �Ӽ� �ʱ�ȭ �Լ� ȣ��
            bullet.GetComponent<Bullet>().Init(damage, -1); // -1 is Infinity Per.
        }
    }
}
