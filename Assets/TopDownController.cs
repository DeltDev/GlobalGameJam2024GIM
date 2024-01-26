using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{

    [SerializeField] private float MoveSpeed;
    private Rigidbody2D rb2D;
    private float moveHorizontal;
    private float moveVertical;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        Debug.Log(moveHorizontal);
    }
    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(moveHorizontal * MoveSpeed, moveVertical*MoveSpeed);
    }
}
