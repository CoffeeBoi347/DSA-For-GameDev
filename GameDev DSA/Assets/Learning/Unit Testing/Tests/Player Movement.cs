using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocity = 50;
    public float jumpPower = 20;
    public void MoveDirection(Vector3 direction)
    {
        transform.position += direction * velocity * Time.deltaTime;
    }

    public void JumpPlayer()
    {
        transform.position += Vector3.up * jumpPower * Time.deltaTime;
    }
}