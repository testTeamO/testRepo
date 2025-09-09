using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 쿼터뷰에서 플레이어 입력을 월드 좌표계로 바꿔 전달하는 클래스
/// </summary>
public class QuarterViewInputHandler : PlayerInputHandler
{
    [SerializeField] Transform _cameraTransform;

    public override event Action<Vector3> OnMoveInput;

    public override void FixedUpdate()
    {
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

        OnMoveInput?.Invoke(moveDir);
    }
}