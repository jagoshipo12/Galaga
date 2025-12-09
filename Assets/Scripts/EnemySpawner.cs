using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;  //적 색성을 위한 스테이지 크기 정보 
    [SerializeField]
    private GameObject enemyPrefab;  //복제해서 생성할 적 캐릭터 프리팹 
    [SerializeField]
    private BGMController bgmController; //배경음악 설정(보스 등장 시 변경)
    [SerializeField]
    private GameObject textBossWarning; //보스 등장 텍스트 오브젝트
    [SerializeField]
    private GameObject boss; //보스 오브젝트
    [SerializeField]
    private float spawnTime; //생성 주기 
    [SerializeField]
    private int maxEnemyCount = 100; //현재 스테이지의 최대 적 생성 숫자

    private void Awake()
    {
        //보스 등장 텍스트 비활성화 
        textBossWarning.SetActive(false);
        //보스 오브젝트 비활성화 
        boss.SetActive(false);

        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        int currentEnemyCount = 0; //적 생성 숫자 카운터용 변수
        while (true)
        {
            // x 위치는 스테이지의 크기 범위 내에서 임의의 값을 선택 
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            //적 캐릭터 생성 
            Instantiate(enemyPrefab, new Vector3(positionX, stageData.LimitMax.y+1.0f, 0.0f), Quaternion.identity);

            //적 생성 숫자 증가
            currentEnemyCount++;  
            // 적을 최대 숫자까지 생성하면 적 생성 코루틴 중지, 보스 생성 코루틴 실행
            if (currentEnemyCount == maxEnemyCount)
            {
                StartCoroutine("SpawnBoss"); 
                break;
            }
            // spawnTime만큼 대기 
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private IEnumerator SpawnBoss()
    {
        //보스 등장 BGM 설정 
        bgmController.ChangeBGM(BGMType.Boss); //bgmcontroller.Change(1); 보다 가독성이 좋다. 
        //보스 등장 텍스트 활성화 
        textBossWarning.SetActive(true);
        //1초 대기 
        yield return new WaitForSeconds(1.0f); 

        //보스 등장 텍스트 비활성화 
        textBossWarning.SetActive(false );
        //보스 오브젝트 활성화 
        boss.SetActive(true);
    }
}