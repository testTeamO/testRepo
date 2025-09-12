using UnityEngine;

/// <summary>
/// ĳ������ ȸ���� ����ϴ� �߻� Ŭ����
/// </summary>
public abstract class Rotator : MonoBehaviour
{
    [SerializeField] float _rotSpeed;

    public float RotSpeed => _rotSpeed;

    /// <summary>
    /// ��ü�� �Է��� �������� ȸ����Ű�� �Լ�
    /// </summary>
    /// <param name="direction"></param>
    public abstract void Rotate(Vector3 direction);

    /// <summary>
    /// ��ü�� ȸ���ӵ��� �����ϴ� �Լ�
    /// </summary>
    /// <param name="rotSpeed"></param>
    public void SetRotSpeed(float rotSpeed)
    {
        _rotSpeed = rotSpeed;
    }
}
