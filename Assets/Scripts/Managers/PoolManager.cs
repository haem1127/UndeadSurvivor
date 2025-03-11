using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // ��������� ������ ���� 
    public GameObject[] prefabs;
    // Ǯ ����� �ϴ� ����Ʈ�� 
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        // index�� 2���� ������ ��� ����
        // �ݺ����� ���� ��� ������Ʈ Ǯ ����Ʈ�� �ʱ�ȭ
        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }

        Debug.Log(pools.Length);
    }

    // ���� ������Ʈ�� ��ȯ�ϴ� �Լ� ����
    public GameObject Get(int index)
    {
        // ���� ������Ʈ ���������� ������ �̸� �ۼ�
        GameObject select = null;

        // ������ Ǯ�� ���(��Ȱ��ȭ ��) �ִ� ���ӿ�����Ʈ ����
           
        foreach(GameObject item in pools[index])
        {
            // ���빰 ������Ʈ�� ��Ȱ��ȭ(������)���� Ȯ��

            if (!item.activeSelf)
            {   
                // �߰��ϸ� select ������ �Ҵ�
                select = item;
                // ��Ȱ��ȭ ������Ʈ�� ã���� SetActive �Լ��� Ȱ��ȭ
                select.SetActive(true);
                // �ݺ��� ����
                break;
            }
        }
        
        // �� ã������?
        // �̸� ������ ������ ��������� ������������ ����
        if (!select)
        {
            // ���Ӱ� �����ϰ� select ������ �Ҵ�
            // Instantiate: ���� ������Ʈ�� �����Ͽ� ��鿡 �����ϴ� �Լ�
            select = Instantiate(prefabs[index], transform);
            // ������ ������Ʈ�� �ش� ������Ʈ Ǯ ����Ʈ�� Add �Լ��� �߰�
            pools[index].Add(select);
        }


        return select;
    }

}
