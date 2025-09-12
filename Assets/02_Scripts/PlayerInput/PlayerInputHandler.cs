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
    public override event Action<Vector2> OnMousePositionChanged;
    public override event Action OnInteractInput;

    public void FixedUpdate()
    {
        // �̵� �Է¿� ���� �̺�Ʈ ����
        OnMoveInput?.Invoke(_moveInput);

        // ���콺 ��ġ �Է¿� ���� �Լ� ����
        GetMousePosition();
    }

    /// <summary>
    /// �̵� �Է��� �޾��� �� Vector2 ������ �Է°��� Vector3 ���·� ��ȯ�Ͽ� �����ϴ� �Լ�
    /// </summary>
    /// <param name="inputValue"></param>
    public virtual void OnMove(InputValue inputValue)
    {
        Vector2 moveInput = inputValue.Get<Vector2>();
        _moveInput = new Vector3(moveInput.x, 0, moveInput.y);
    }

    /// <summary>
    /// ���콺 �Է��� �޾� ���� ���콺 ��ġ�� �����ϰ� �̺�Ʈ �����ϴ� �Լ�
    /// </summary>
    public virtual void GetMousePosition()
    {
        _mousePosition = Mouse.current.position.ReadValue();
        OnMousePositionChanged?.Invoke(_mousePosition);
    }

    public void OnInteract(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            OnInteractInput?.Invoke();
            Debug.Log("��ȣ�ۿ� Ű ����");
        }
    }

    ///// <summary>
    ///// ���콺 �̵� �Է��� �޾��� �� �Է°��� �����ϰ� �̺�Ʈ ����
    ///// </summary>
    ///// <param name="inputValue"></param>
    //public void OnLook(InputValue inputValue)
    //{
    //    Vector2 lookInput = inputValue.Get<Vector2>();
    //    _lookInput = lookInput;
    //    OnLookInput?.Invoke(_lookInput);
    //}

}