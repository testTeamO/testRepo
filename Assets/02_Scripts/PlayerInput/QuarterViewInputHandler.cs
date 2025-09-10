using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 쿼터뷰에서 플레이어 입력을 월드 좌표계로 바꿔 전달하는 클래스
/// </summary>
public class QuarterViewInputHandler : PlayerInputHandler
{
    [SerializeField] Transform _cameraTransform;

    /// <summary>
    /// 쿼터뷰 카메라 기준으로 이동 입력을 변환하여 전달
    /// </summary>
    /// <param name="inputValue"></param>
    public override void OnMove(InputValue inputValue)
    {
        Vector2 moveInput = inputValue.Get<Vector2>();
        _moveInput = new Vector3(moveInput.x, 0, moveInput.y);

        Vector3 moveDir = _moveInput;

        // 쿼터뷰 카메라 기준으로 변환
        if (_cameraTransform != null)
        {
            Vector3 camForward = _cameraTransform.forward;
            Vector3 camRight = _cameraTransform.right;
            camForward.y = 0;
            camRight.y = 0;
            camForward.Normalize();
            camRight.Normalize();
            moveDir = camForward * _moveInput.z + camRight * _moveInput.x;
        }

        _moveInput = moveDir.normalized;
    }
}