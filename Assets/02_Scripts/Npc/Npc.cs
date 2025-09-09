using UnityEngine;

public class Npc : MonoBehaviour, IInteractable
{
    public void Interact(GameObject interactor)
    {
        Debug.Log($"{interactor.name} interacted with {gameObject.name}");
    }
}