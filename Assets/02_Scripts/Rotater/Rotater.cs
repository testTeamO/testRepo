using UnityEngine;

/// <summary>
/// ĳ������ ȸ���� ����ϴ� �߻� Ŭ����
/// </summary>
public abstract class Rotater : MonoBehaviour
{
    [SerializeField] float _rotSpeed;

    public float RotSpeed => _rotSpeed;

    /// <summary>
    /// ��ü�� ȸ����Ű�� �Լ�
    /// </summary>
    /// <param name="lookInput"></param>
    public abstract void Rotate(Vector2 lookInput);

    /// <summary>
    /// ��ü�� ȸ���ӵ��� �����ϴ� �Լ�
    /// </summary>
    /// <param name="rotSpeed"></param>
    public void SetRotSpeed(float rotSpeed)
    {
        _rotSpeed = rotSpeed;
    }
}
