using UnityEngine;

/// <summary>
/// 캐릭터의 회전을 담당하는 추상 클래스
/// </summary>
public abstract class Rotator : MonoBehaviour
{
    [SerializeField] float _rotSpeed;

    public float RotSpeed => _rotSpeed;

    /// <summary>
    /// 물체를 입력한 방향으로 회전시키는 함수
    /// </summary>
    /// <param name="direction"></param>
    public abstract void Rotate(Vector3 direction);

    /// <summary>
    /// 물체의 회전속도를 설정하는 함수
    /// </summary>
    /// <param name="rotSpeed"></param>
    public void SetRotSpeed(float rotSpeed)
    {
        _rotSpeed = rotSpeed;
    }
}
