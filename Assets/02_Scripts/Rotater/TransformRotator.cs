using UnityEngine;

public class TransformRotator : Rotator
{
    /// <summary>
    /// 입력한 방향으로 물체가 자연스럽게 바라보도록 회전시키는 함수
    /// </summary>
    /// <param name="direction"></param>
    public override void Rotate(Vector3 direction)
    {
        if (direction.sqrMagnitude < 0.01f)
            return;
        // Vector3로 값을 받았기 때문에 z값에 y값을 넣을 필요가 없다.
        // 이거때문에 회전이 이상하게 됨
        // Vector3 lookDir = new Vector3(direction.x, 0f, direction.y);
        Vector3 lookDir = new Vector3(direction.x, 0f, direction.z);
        Quaternion targetRot = Quaternion.LookRotation(lookDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, RotSpeed * Time.fixedDeltaTime);
    }
}