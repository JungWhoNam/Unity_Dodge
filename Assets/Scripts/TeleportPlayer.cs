using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(0, 1, 0);
        }
    }
}
