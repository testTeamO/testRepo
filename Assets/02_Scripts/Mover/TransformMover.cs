using UnityEngine;

public class TransformMover : Mover
{
    public override void Move(Vector3 direction)
    {
        transform.position += MoveSpeed * Time.fixedDeltaTime * direction;

        //// 방향이 있으면 회전
        //if (direction.sqrMagnitude > 0.01f)
        //{
        //    Quaternion targetRot = Quaternion.LookRotation(direction);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, RotSpeed * Time.deltaTime);
        //}
    }
}
