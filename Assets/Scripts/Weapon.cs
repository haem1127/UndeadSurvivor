using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // 무기 id, 프리펩 id, 데미지, 개수, 속도 변수 선언
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
            // 가져온 오브젝트의 Transform을 지역변수로 저장
            Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
            // parent 속성을 통해 부모 변경
            bullet.parent = transform;
            // Bullet 컴포넌트 접근하여 속성 초기화 함수 호출
            bullet.GetComponent<Bullet>().Init(damage, -1); // -1 is Infinity Per.
        }
    }
}
