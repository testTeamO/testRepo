using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// (임시) 영웅 캐릭터 클래스
/// </summary>
public class Hero : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] Mover _mover;
    [SerializeField] Rotator _rotator;
    [SerializeField] InputHandler _inputHandler;
    [SerializeField] InteractableDetector _interactableDetector;

    [SerializeField] Camera _camera;

    private void Start()
    {
        _inputHandler.OnMoveInput += _mover.Move;
        _inputHandler.OnMousePositionChanged += HandleMousePositionChanged;
    }

    private void Update()
    {
        
    }

    /// <summary>
    /// 입력받은 마우스 위치의 Vector2 값을 받아서
    /// Vector3로 변환 후 Rotator의 Rotate 메서드를 호출
    /// </summary>
    /// <param name="mousePosition"></param>
    void HandleMousePositionChanged(Vector2 mousePosition)
    {
        // testtesttest


        // 1. 스크린 좌표 → 월드 평면(y=플레이어 높이) 변환
        Ray ray = _camera.ScreenPointToRay(mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position); // y=플레이어 위치 평면
        float enter;
        if (plane.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);

            // 2. 회전 방향 계산
            Vector3 dir = hitPoint - transform.position;

            // 3. Rotator에 방향 전달
            _rotator.Rotate(dir);
        }
    }
}
