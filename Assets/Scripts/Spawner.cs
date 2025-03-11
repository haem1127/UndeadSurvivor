using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    // ��ȯ Ÿ�̸Ӹ� ���� ���� ����
    float timer;

    private void Awake()
    {
        // �ʱ�ȭ
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        // += �캯�� �º��� ��� ���ϴ�
        // Ÿ�̸� �������� deltaTime�� ��� ���ϱ�
        timer += Time.deltaTime;

        // Ÿ�̸Ӱ� ���� �ð� ���� �����ϸ� ��ȯ�ϵ��� �ۼ�
        if(timer > 0.2f)
        {
            timer= 0;
            Spawn();
        }

        void Spawn()
        {
            // Ǯ �Լ� �ȿ��� ���� ���ڸ� �ֵ��� ����
            GameObject enemy = GameManager.instance.pool.Get(Random.Range(0,2));
            // �ڽ��� ������ �ڽ� ������Ʈ�������� ���õǵ��� ���� ������ 1����
            enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        }
    }
}
