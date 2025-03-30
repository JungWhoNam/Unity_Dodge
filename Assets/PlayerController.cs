using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody; // �̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f; // �̵� �ӷ�

    void Start()
    {

    }

    void Update()
    {
        // ����� ���� �� �Է� ���� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �Ǵ� ���� �� �Է� ���� ���� ���� linearVelocity�� ����
        if (xInput != 0 || zInput != 0)
        {
            // ���� �̵� �ӵ��� �Է� ���� �̵� �ӷ��� ���� ����
            float xSpeed = xInput * speed;
            float zSpeed = zInput * speed;

            // Vector3 �ӵ��� (xSpeed, 0, zSpeed)���� ����
            Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
            // ������ٵ��� �ӵ��� newVelocity�� �Ҵ�
            playerRigidbody.linearVelocity = newVelocity;
        }
    }

    public void Die()
    {
        // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
