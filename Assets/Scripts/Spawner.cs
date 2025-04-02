using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    // 만든 클래스를 그대로 타입으로 활용하여 배열 변수 선언
    public SpawnData[] spawnData;

    int level;
    // 소환 타이머를 위한 변수 선언
    float timer;

    private void Awake()
    {
        // 초기화
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        // += 우변을 좌변에 계속 더하다
        // 타이머 변수에는 deltaTime을 계속 더하기
        timer += Time.deltaTime;
        // FloorToInt는 소수점 아래는 버리고 Int형으로 바꾸는 함수이다
        // CeilToInt는 소수점 아래를 올리고 Int형으로 바꾸는 함수이다
        // Mathf.Min 함수로 인덱스 에러를 막을 수 있다
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 1);


        // 타이머가 일정 시간 값에 도달하면 소환하도록 작성
        // 소환 시간 조건을 소환 데이터로 변경
        if(timer > spawnData[level].spawnTime)
        {
            timer= 0;
            Spawn();
        }

        void Spawn()
        {
            // 풀 함수 안에는 랜덤 인자를 넣도록 변경 > 풀링에서 가져오는 함수에도 레벨 적용
            GameObject enemy = GameManager.instance.pool.Get(0);
            // 자신을 제외한 자식 오브젝트에서부터 선택되도록 랜덤 시작은 1부터
            enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
            // 새롭게 작성한 함수를 호출하고 소환데이터 인자값 전달
            enemy.GetComponent<Enemy>().Init(spawnData[level]);
        }
    }
}
// 소환 데이터를 담당하는 클래스 선언 및 직렬화(Serialization: 개체를 저장 혹은 전송하기 위해 변환)
[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;
}
