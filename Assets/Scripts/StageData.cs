using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject  //부모 클래스로 ScriptablObject를 사용하면 해당 클래스를 에셋 파일의 형태로 저장할 수 있음
{
    [SerializeField]
    private Vector2 limitMin;
    [SerializeField]
    private Vector2 limitMax;

    public Vector2 LimitMin => limitMin; 
    public Vector2 LimitMax => limitMax;
}


//현재 스테이지의 화면 내 범위 
//에셋 데이터로 저장해두고 정보를 불러와서 사용