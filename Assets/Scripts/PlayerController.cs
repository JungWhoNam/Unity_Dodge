using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody; // 이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; // 이동 속력

    private int health = 3;

    void Start()
    {
    }

    void Update()
    {
        // 수평과 수직 축 입력 값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력 값과 이동 속력을 통해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 속도를 (xSpeed, 기존 y 속도, zSpeed)으로 생성
        Vector3 newVelocity = new Vector3(xSpeed, playerRigidbody.linearVelocity.y, zSpeed);
        // 리지드바디의 속도에 newVelocity를 할당
        playerRigidbody.linearVelocity = newVelocity;
    }

    public void Die()
    {
        health -= 1;

        this.GetComponent<Renderer>().material.color = Color.yellow;

        if (health <= 0)
        {
            // 자신의 게임 오브젝트를 비활성화
            gameObject.SetActive(false);

            // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
            GameManager gameManager = FindFirstObjectByType<GameManager>();
            // 가져온 GameManager 오브젝트의 EndGame() 메서드 실행
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
    
    public int GetHealth()
    {
        return health;
    }
}
