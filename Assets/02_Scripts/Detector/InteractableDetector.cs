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

    public event Action<IInteractable> OnInteractableDetected; // 상호작용 가능한 물체가 감지되었을 때 발생하는 이벤트

    private void Update()
    {
        int hitCount = Physics.OverlapSphereNonAlloc(transform.position, _detectionRadius, _hits, _targetMask);

        if (hitCount <= 0) return;

        for (int i = 0; i < hitCount; i++)
        {
            Collider col = _hits[i];
            
            // 인터페이스가 붙어 있는지 검사
            var interactable = col.GetComponent<IInteractable>();
            if (interactable != null)
            {
                OnInteractableDetected?.Invoke(interactable);
                break; // 하나만 상호작용하고 종료
            }
        }
    }
}
