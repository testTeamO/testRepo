using System;
using UnityEngine;

/// <summary>
/// ���ӿ�����Ʈ�� �̵���Ű�� ����� ����ϴ� �߻� Ŭ����
/// </summary>
public abstract class Mover : MonoBehaviour
{
    [SerializeField] float _moveSpeed;

    public float MoveSpeed => _moveSpeed;

    /// <summary>
    /// ��ü�� �̵���Ű�� �Լ�
    /// </summary>
    /// <param name="direction"></param>
    public abstract void Move(Vector3 direction);

    /// <summary>
    /// ��ü�� �̵��ӵ��� �����ϴ� �Լ�
    /// </summary>
    /// <param name="moveSpeed"></param>
    public void SetMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }
}
