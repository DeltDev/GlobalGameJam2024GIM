using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{

    [SerializeField] private float MoveSpeed;
    private Rigidbody2D rb2D;
    private float moveHorizontal;
    private float moveVertical;
    private float angle;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 Movement = new Vector2(moveHorizontal, moveVertical);
        Movement.Normalize();
        rb2D.velocity= Movement *MoveSpeed;

        if(Movement != Vector2.zero)
        {
            angle = Mathf.Atan2(Movement.y,Movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0,0,angle);
        }
    }
    
}
