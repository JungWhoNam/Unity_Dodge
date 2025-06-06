using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리 관련 라이브러리
using TMPro; // TextMeshPro 라이브러리

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글턴을 할당할 전역 변수

    public GameObject gameoverText; // 게임오버시 활성화 할 텍스트 게임 오브젝트
    public TMP_Text timeText; // 생존 시간을 표시할 텍스트 컴포넌트
    public TMP_Text recordText; // 최고 기록을 표시할 텍스트 컴포넌트
    public TMP_Text hpText; // HP 표시할 텍스트 컴포넌트

    public PlayerController playerController;

    private float surviveTime; // 생존 시간
    private bool isGameover; // 게임 오버 상태

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다.");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // 생존 시간과 게임 오버 상태를 초기화
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        hpText.text = "HP: " + playerController.GetHealth().ToString();

        // 게임 오버가 아닌 동안
        if (!isGameover)
        {
            // 생존 시간 갱신
            surviveTime += Time.deltaTime;
            // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 통해 표시
            timeText.text = "Time: " + (int)surviveTime;

            if (PlayerPrefs.GetFloat("BestTime") < surviveTime)
            {
                timeText.text += " (NEW)";
            }
        }
        else
        {
            // 게임 오버인 상태에서 키보드 R키를 누른 경우
            if (Input.GetKeyDown(KeyCode.R))
            {
                // SampleScene 씬을 로드
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    // 현재 게임을 게임 오버 상태로 변경하는 메서드
    public void EndGame()
    {
        // 현재 상태를 게임 오버 상태로 전환
        isGameover = true;
        // 게임 오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        // BestTime 키로 저장된, 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if (surviveTime > bestTime)
        {
            // 최고 기록의 값을 현재 생존 시간의 값으로 변경 
            bestTime = surviveTime;
            // 변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // 최고 기록을 recordText 텍스트 컴포넌트를 통해 표시
        recordText.text = "Best Time: " + (int)bestTime;
    }
}