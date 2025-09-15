using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// New InputSystem을 통해 플레이어의 입력을 받아
/// 입력들을 처리하는 클래스
/// </summary>
public class PlayerInputHandler : InputHandler
{
    public override event Action<Vector3> OnMoveInput;
    public override event Action<Vector2> OnMousePositionChanged;
    public override event Action OnInteractInput;

    public void FixedUpdate()
    {
        // 이동 입력에 대한 이벤트 발행
        OnMoveInput?.Invoke(_moveInput);

        // 마우스 위치 입력에 대한 함수 실행
        GetMousePosition();
    }

    /// <summary>
    /// 이동 입력을 받았을 때 Vector2 형태의 입력값을 Vector3 형태로 변환하여 저장하는 함수
    /// </summary>
    /// <param name="inputValue"></param>
    public virtual void OnMove(InputValue inputValue)
    {
        Vector2 moveInput = inputValue.Get<Vector2>();
        _moveInput = new Vector3(moveInput.x, 0, moveInput.y);
    }

    /// <summary>
    /// 마우스 입력을 받아 현재 마우스 위치를 저장하고 이벤트 발행하는 함수
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
            Debug.Log("상호작용 키 눌림");
        }
    }

    ///// <summary>
    ///// 마우스 이동 입력을 받았을 때 입력값을 저장하고 이벤트 발행
    ///// </summary>
    ///// <param name="inputValue"></param>
    //public void OnLook(InputValue inputValue)
    //{
    //    Vector2 lookInput = inputValue.Get<Vector2>();
    //    _lookInput = lookInput;
    //    OnLookInput?.Invoke(_lookInput);
    //}

}