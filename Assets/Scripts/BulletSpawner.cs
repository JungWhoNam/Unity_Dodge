using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ �Ѿ��� ���� ������
    public float spawnRateMin = 0.5f; // �ּ� ���� �ֱ�
    public float spawnRateMax = 3f; // �ִ� ���� �ֱ�

    private Transform target; // �߻��� ���
    private float spawnRate; // ���� �ֱ�
    private float timeAfterSpawn; // �ֱ� ���� �������� ���� �ð�

    void Start()
    {
        // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        // �Ѿ� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� ���� 
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
        target = FindFirstObjectByType<PlayerController>().transform;
    }

    void Update()
    {
        // timeAfterSpawn�� ����
        timeAfterSpawn += Time.deltaTime;

        float dist = Vector3.Distance(transform.position, target.position);
        if (dist < 2f)
        {
            GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);

            // �ֱ� ���� ������������ ������ �ð���, ���� �ֱ⺸�� ũ�ų� ���ٸ�
            if (timeAfterSpawn >= spawnRate)
            {
                // ������ �ð��� ����
                timeAfterSpawn = 0f;

                // bulletPrefab�� ��������
                // transform.position ��ġ�� transform.rotation ȸ������ ����
                GameObject bullet
                    = Instantiate(bulletPrefab, transform.position, transform.rotation);
                // ������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
                bullet.transform.LookAt(target);

                // ������ ���� ������ spawnRateMin, spawnRateMax ���̿��� ���� ����
                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
        }
    }
}
