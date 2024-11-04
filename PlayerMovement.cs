using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    void Update()
    {
        Vector2 move = Vector2.zero;

        if (Input.GetKey(upKey))
            move.y += 1;
        if (Input.GetKey(downKey))
            move.y -= 1;
        if (Input.GetKey(leftKey))
            move.x -= 1;
        if (Input.GetKey(rightKey))
            move.x += 1;

        transform.Translate(move * speed * Time.deltaTime);
    }
}

