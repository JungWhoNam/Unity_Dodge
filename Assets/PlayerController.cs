using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody; // 이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; // 이동 속력

    void Start()
    {

    }

    void Update()
    {
        // 수평과 수직 축 입력 값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 수평 또는 수직 축 입력 값이 있을 때만 linearVelocity를 설정
        if (xInput != 0 || zInput != 0)
        {
            // 실제 이동 속도를 입력 값과 이동 속력을 통해 결정
            float xSpeed = xInput * speed;
            float zSpeed = zInput * speed;

            // Vector3 속도를 (xSpeed, 0, zSpeed)으로 생성
            Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
            // 리지드바디의 속도에 newVelocity를 할당
            playerRigidbody.linearVelocity = newVelocity;
        }
    }

    public void Die()
    {
        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);
    }
}
