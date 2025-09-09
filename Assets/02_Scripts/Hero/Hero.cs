using UnityEngine;

/// <summary>
/// (임시) 영웅 캐릭터 클래스
/// </summary>
public class Hero : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] Mover _mover;
    [SerializeField] InputHandler _inputHandler;
    [SerializeField] InteractableDetector _interactableDetector;

    private void Start()
    {
        _inputHandler.OnMoveInput += _mover.Move;
    }

    private void Update()
    {
        
    }
}
