using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    int level;
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
        // FloorToInt�� �Ҽ��� �Ʒ��� ������ Int������ �ٲٴ� �Լ��̴�
        // CeilToInt�� �Ҽ��� �Ʒ��� �ø��� Int������ �ٲٴ� �Լ��̴�
        level = Mathf.FloorToInt(GameManager.instance.gameTime / 10f);

        // Ÿ�̸Ӱ� ���� �ð� ���� �����ϸ� ��ȯ�ϵ��� �ۼ�
        if(timer > (level == 0 ? 0.5f : 0.2f))
        {
            timer= 0;
            Spawn();
        }

        void Spawn()
        {
            // Ǯ �Լ� �ȿ��� ���� ���ڸ� �ֵ��� ���� > Ǯ������ �������� �Լ����� ���� ����
            GameObject enemy = GameManager.instance.pool.Get(level);
            // �ڽ��� ������ �ڽ� ������Ʈ�������� ���õǵ��� ���� ������ 1����
            enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        }
    }
}
