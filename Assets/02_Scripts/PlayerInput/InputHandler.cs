using System;
using UnityEngine;

/// <summary>
/// 입력을 받았을 때 입력값을 이벤트를 통해 전달하는 추상 클래스
/// </summary>
public abstract class InputHandler : MonoBehaviour
{
    protected Vector3 _moveInput;
    protected Vector2 _mousePosition;

    public abstract event Action<Vector3> OnMoveInput; // 이동 입력 이벤트
    public abstract event Action<Vector2> OnMousePositionChanged; // 마우스 위치 변경 이벤트
    public abstract event Action OnInteractInput; // 상호작용 입력 이벤트
}
