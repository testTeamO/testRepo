using UnityEngine;

public interface IInteractable
{
    /// <summary>
    /// 상호작용 가능한 물체와 상호작용을 시도합니다.
    /// </summary>
    /// <param name="interactor">상호작용을 시도하는 객체</param>
    void Interact(GameObject interactor);
}