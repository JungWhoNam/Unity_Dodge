using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; // 탄알 이동 속력
    private Rigidbody bulletRigidbody; //이동에 사용할 리지드바디 컴포넌트

    private float timeSince; // 생성된 후 시간

    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        // 리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        bulletRigidbody.linearVelocity = transform.forward * speed;

        // 3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        PlayerController playerController = FindFirstObjectByType<PlayerController>();
        if (playerController != null)
        {
            // TODO 총알이 Player를 따라가게 구현
            Vector3 dir = playerController.transform.position - transform.position;
            bulletRigidbody.linearVelocity = dir.normalized * speed;
        }

        timeSince += Time.deltaTime;
        GetComponent<MeshRenderer>().material.color = new Color(1f - timeSince / 3f, 0, 0);
    }

    // 트리거 충돌 시 자동으로 실행되는 메서드
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Player")
        {
            // 상대방 게임 오브젝트에서 PlayerController 컴포넌트를 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            // 상대방으로부터 PlayerController 컴포넌트를 가져오는데 성공했다면
            if (playerController != null)
            {
                // 상대방 PlayerController 컴포넌트의 Die() 메서드 실행
                playerController.Die();

                // 게임 오브젝트 파괴
                Destroy(gameObject);
            }
        }
    }
}
