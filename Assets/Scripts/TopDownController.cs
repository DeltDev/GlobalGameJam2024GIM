using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClampPlayer {
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
}

public class TopDownController : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    private Rigidbody2D rb2D;
    private float moveHorizontal;
    private float moveVertical;
    private float angle;
    public bool disableRotation;
    [SerializeField] private ClampPlayer clampPlayer;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        disableRotation= false;
    }

    private void ClampPosition ()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, clampPlayer.minX, clampPlayer.maxX);
        position.y = Mathf.Clamp(position.y, clampPlayer.minY, clampPlayer.maxY);
        transform.position = position;
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 Movement = new Vector2(moveHorizontal, moveVertical);
        Movement.Normalize();
        rb2D.velocity= Movement *MoveSpeed;

        if(Movement != Vector2.zero && !disableRotation)
        {
            float yRot = Movement.x < 0 ? 180 : 0;
            float zRot = 0;

            if (Movement.y != 0) {
                zRot = Movement.y > 0 ? 45 : -45;
            }
            transform.rotation = Quaternion.Euler(0,yRot, zRot);
        }
        ClampPosition();
    }
}
