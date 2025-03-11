using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

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

        // 타이머가 일정 시간 값에 도달하면 소환하도록 작성
        if(timer > 0.2f)
        {
            timer= 0;
            Spawn();
        }

        void Spawn()
        {
            // 풀 함수 안에는 랜덤 인자를 넣도록 변경
            GameObject enemy = GameManager.instance.pool.Get(Random.Range(0,2));
            // 자신을 제외한 자식 오브젝트에서부터 선택되도록 랜덤 시작은 1부터
            enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        }
    }
}
