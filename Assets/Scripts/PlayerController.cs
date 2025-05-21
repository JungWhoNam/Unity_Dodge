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


        // Option #1: ������ٵ� ���
        // Vector3 �ӵ��� (xSpeed, ���� y �ӵ�, zSpeed)���� ����
        //Vector3 newVelocity = new Vector3(xSpeed, playerRigidbody.linearVelocity.y, zSpeed);
        //playerRigidbody.linearVelocity = newVelocity;


        // Option #2: transform.position ���
        Vector3 newVelocity = new Vector3(xSpeed,0, zSpeed);
        transform.position += newVelocity * Time.deltaTime;
    }

    public void Die()
    {
        health -= 1;

        // �÷��̾� �ʱ� ���� (0, 100, 165).
        Color c = new Color(0f * health / 3f, 100f / 255f * health / 3f, 164f / 255f * health / 3f);
        GetComponent<MeshRenderer>().material.color = c;

        if (health <= 0)
        {
            // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
            gameObject.SetActive(false);

            //// ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
            //GameManager gameManager = FindFirstObjectByType<GameManager>();
            //// ������ GameManager ������Ʈ�� EndGame() �޼��� ����
            //if (gameManager != null)
            //{
            //    gameManager.EndGame();
            //}

            if (GameManager.instance != null )
                GameManager.instance.EndGame();
        }
    }

    public void IncreaseHealth(int amt)
    {
        if (amt <= 0) return;

        health += amt;

        // �÷��̾� �ʱ� ���� (0, 100, 165).
        Color c = new Color(0f * health / 3f, 100f / 255f * health / 3f, 164f / 255f * health / 3f);
        GetComponent<MeshRenderer>().material.color = c;
    }
    
    public int GetHealth()
    {
        return health;
    }
}
