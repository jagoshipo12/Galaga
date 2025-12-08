using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerHP playerHP;
    private Slider sliderHP;

    private void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }

    //체력 정보가 바뀔때면 UI 정보 갱신 
    private void Update()
    {
        //Slider UI에 현재 체력 정보를 업데이트 
        sliderHP.value = playerHP.CurrentHP / playerHP.MaxHP;
    }
}
