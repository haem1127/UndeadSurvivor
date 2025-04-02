using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    // ���� Ŭ������ �״�� Ÿ������ Ȱ���Ͽ� �迭 ���� ����
    public SpawnData[] spawnData;

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
        // Mathf.Min �Լ��� �ε��� ������ ���� �� �ִ�
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 1);


        // Ÿ�̸Ӱ� ���� �ð� ���� �����ϸ� ��ȯ�ϵ��� �ۼ�
        // ��ȯ �ð� ������ ��ȯ �����ͷ� ����
        if(timer > spawnData[level].spawnTime)
        {
            timer= 0;
            Spawn();
        }

        void Spawn()
        {
            // Ǯ �Լ� �ȿ��� ���� ���ڸ� �ֵ��� ���� > Ǯ������ �������� �Լ����� ���� ����
            GameObject enemy = GameManager.instance.pool.Get(0);
            // �ڽ��� ������ �ڽ� ������Ʈ�������� ���õǵ��� ���� ������ 1����
            enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
            // ���Ӱ� �ۼ��� �Լ��� ȣ���ϰ� ��ȯ������ ���ڰ� ����
            enemy.GetComponent<Enemy>().Init(spawnData[level]);
        }
    }
}
// ��ȯ �����͸� ����ϴ� Ŭ���� ���� �� ����ȭ(Serialization: ��ü�� ���� Ȥ�� �����ϱ� ���� ��ȯ)
[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;
}
