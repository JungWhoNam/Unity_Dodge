using UnityEngine;

public class TrunOffCollider : MonoBehaviour
{
    // ��Ÿ�� �ڵ�
    // BoxCollider ������Ʈ�� ���� ���� (Inspector���� �Ҵ� ����)
    public BoxCollider boxCollider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { // �����̽��ٰ� ������ ����
            boxCollider.enabled = false; // BoxCollider�� ��Ȱ��ȭ (�浹 ���� OFF)
            Debug.Log("BoxCollider�� ��Ȱ��ȭ�Ǿ����ϴ�."); // �ֿܼ� �޽��� ���
        }
    }


    //// ��� #1
    //public BoxCollider collider0;
    //public SphereCollider collider1;
    //public CapsuleCollider collider2;

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        collider0.enabled = false;
    //        collider1.enabled = false;
    //        collider2.enabled = false;
    //    }
    //}

    //// ��� #2 - �迭 ���
    //public Collider[] colliders;

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        foreach (Collider c in colliders)
    //        {
    //            c.enabled = false;
    //        }
    //    }
    //}
}