using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;

    //이동 속도, 이동 방향을 Inspector에서 설정할 수 있도록 SerializedField 작성
    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime; 
    } 

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
    //외부에서 MoveTo 함수를 이용해 이동 방향을 설정할 수 있도록 작성
}
