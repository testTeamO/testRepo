using UnityEngine;

public class TransformMover : Mover
{
    public override void Move(Vector3 direction)
    {
        transform.position += MoveSpeed * Time.fixedDeltaTime * direction;

    }
}
