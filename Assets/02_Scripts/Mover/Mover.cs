using System;
using UnityEngine;

/// <summary>
/// 게임오브젝트를 이동시키는 기능을 담당하는 추상 클래스
/// </summary>
public abstract class Mover : MonoBehaviour
{
    [SerializeField] float _moveSpeed;

    public float MoveSpeed => _moveSpeed;

    /// <summary>
    /// 물체를 이동시키는 함수
    /// </summary>
    /// <param name="direction"></param>
    public abstract void Move(Vector3 direction);

    /// <summary>
    /// 물체의 이동속도를 설정하는 함수
    /// </summary>
    /// <param name="moveSpeed"></param>
    public void SetMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }
}
