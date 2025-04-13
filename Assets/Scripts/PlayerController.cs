using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody; // �̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f; // �̵� �ӷ�

    private int health = 3;

    void Start()
    {

    }

    void Update()
    {
        // ����� ���� �� �Է� ���� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Է� ���� �̵� �ӷ��� ���� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 �ӵ��� (xSpeed, ���� y �ӵ�, zSpeed)���� ����
        Vector3 newVelocity = new Vector3(xSpeed, playerRigidbody.linearVelocity.y, zSpeed);
        // ������ٵ��� �ӵ��� newVelocity�� �Ҵ�
        playerRigidbody.linearVelocity = newVelocity;
    }

    public void Die()
    {
        health -= 1;

        if (health <= 0)
        {
            // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
            gameObject.SetActive(false);

            // ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
            GameManager gameManager = FindFirstObjectByType<GameManager>();
            // ������ GameManager ������Ʈ�� EndGame() �޼��� ����
            if (gameManager != null)
            {
                gameManager.EndGame();
            }
        }
    }

    public void IncreaseHealth(int amt)
    {
        if (amt <= 0) return;

        health += amt;
    }
}
