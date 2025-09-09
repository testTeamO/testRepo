using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// New InputSystem�� ���� �÷��̾��� �Է��� �޾�
/// �Էµ��� ó���ϴ� Ŭ����
/// </summary>
public class PlayerInputHandler : InputHandler
{
    public override event Action<Vector3> OnMoveInput;
    public override event Action<Vector2> OnLookInput;

    /// <summary>
    /// �̵� �Է��� �޾��� �� Vector2 ������ �Է°��� Vector3 ���·� ��ȯ�Ͽ� ����
    /// </summary>
    /// <param name="inputValue"></param>
    public void OnMove(InputValue inputValue)
    {
        Vector2 moveInput = inputValue.Get<Vector2>();
        _moveInput = new Vector3(moveInput.x, 0, moveInput.y);
    }

    /// <summary>
    /// ���콺 �̵� �Է��� �޾��� �� �Է°��� �����ϰ� �̺�Ʈ ����
    /// </summary>
    /// <param name="inputValue"></param>
    public void OnLook(InputValue inputValue)
    {
        Vector2 lookInput = inputValue.Get<Vector2>();
        _lookInput = lookInput;
        OnLookInput?.Invoke(_lookInput);
    }

    public virtual void FixedUpdate()
    {
        //Debug.Log(_moveInput);
        // �� fixedtime���� �̵� �Է� �̺�Ʈ�� �߻���Ŵ
        OnMoveInput?.Invoke(_moveInput);
    }
}