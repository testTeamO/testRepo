using System;
using UnityEngine;

/// <summary>
/// 상호작용 가능한 물체를 감지하는 컴포넌트로
/// 플레이어가 상호작용 가능한 물체에 접근했을 때 이를 감지하는 역할을 한다.
/// </summary>
public class InteractableDetector : MonoBehaviour
{
    [SerializeField] float _detectionRadius = 1.5f; // 감지 반경
    [SerializeField] LayerMask _targetMask; // 감지할 대상 레이어 마스크

    Collider[] _hits = new Collider[5]; // 감지된 콜라이더를 저장할 배열
    IInteractable _currentInteractable; // 현재 감지된 상호작용 가능한 물체

    public event Action<IInteractable> OnInteractableDetected; // 상호작용 가능한 물체가 감지되었을 때 발생하는 이벤트
    public event Action OnInteractableLost; // 상호작용 가능한 물체가 감지되지 않을 때 발생하는 이벤트

    private void Update()
    {
        DetectInteractable();
    }

    /// <summary>
    /// 주위에 상호작용 가능한 물체가 있는지 감지하는 함수
    /// </summary>
    void DetectInteractable()
    {
        // 영웅으로부터 _detectionRadius 반경 내의 _targetMask 레이어에 속한 콜라이더를 감지하여 _hits 배열에 저장
        int hitCount = Physics.OverlapSphereNonAlloc(transform.position, _detectionRadius, _hits, _targetMask);

        // 감지된 물체가 없으면 현재 상호작용 가능한 물체를 null로 설정하고 이벤트 발생
        if (hitCount <= 0)
        {
            // 감지된 물체가 없으면 null로 설정
            _currentInteractable = null;
            // 상호작용 가능한 물체를 잃었음을 알림
            OnInteractableLost?.Invoke(); 
            return;
        }

        // 감지된 물체가 있으면 배열을 순회하며
        for (int i = 0; i < hitCount; i++)
        {
            // 감지된 콜라이더 가져오기
            Collider col = _hits[i];

            // 인터페이스가 붙어 있는지 검사
            var interactable = col.GetComponent<IInteractable>();
            if (interactable != null)
            {
                // 현재 상호작용 가능한 물체로 설정
                _currentInteractable = interactable;
                // 상호작용 가능한 물체가 감지되었음을 알림
                OnInteractableDetected?.Invoke(_currentInteractable);
                break; // 하나만 상호작용하고 종료
            }
        }
    }

    /// <summary>
    /// 상호작용 키를 눌렀을 때 현재 감지된 상호작용 가능한 물체와 상호작용을 시도하는 함수
    /// </summary>
    public void ExecuteIneraction()
    {
        // 현재 감지된 상호작용 가능한 물체가 있으면
        if (_currentInteractable != null)
        {
            // 해당 물체와 상호작용 시도
            _currentInteractable.Interact(gameObject);
            Debug.Log("Interacted with " + _currentInteractable.ToString());
        }
    }
}
