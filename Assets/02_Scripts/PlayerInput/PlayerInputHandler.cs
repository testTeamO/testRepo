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
    public override event Action<Vector2> OnLookInput;

    /// <summary>
    /// 이동 입력을 받았을 때 Vector2 형태의 입력값을 Vector3 형태로 변환하여 저장
    /// </summary>
    /// <param name="inputValue"></param>
    public void OnMove(InputValue inputValue)
    {
        Vector2 moveInput = inputValue.Get<Vector2>();
        _moveInput = new Vector3(moveInput.x, 0, moveInput.y);
    }

    /// <summary>
    /// 마우스 이동 입력을 받았을 때 입력값을 저장하고 이벤트 발행
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
        // 매 fixedtime마다 이동 입력 이벤트를 발생시킴
        OnMoveInput?.Invoke(_moveInput);
    }
}