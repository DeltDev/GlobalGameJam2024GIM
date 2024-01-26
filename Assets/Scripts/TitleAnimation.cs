using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float PingPongOptimum;
    [SerializeField] private float speed;
    private RectTransform RT;
    private float yDefault,xDefault;
    [SerializeField] private bool Horizontal,flipDirection;
    private void Start()
    {
        RT = GetComponent<RectTransform>();
        yDefault = RT.transform.position.y;
        xDefault = RT.transform.position.x;
    }
    private void FixedUpdate()
    {
        if (Horizontal)
        {
            if (flipDirection)
            {
                RT.transform.position = new Vector3(xDefault - Mathf.PingPong(Time.time * speed, PingPongOptimum) - PingPongOptimum / 2f, RT.transform.position.y, RT.transform.position.z);
            }
            else
            {
                RT.transform.position = new Vector3(xDefault + Mathf.PingPong(Time.time * speed, PingPongOptimum) - PingPongOptimum / 2f,RT.transform.position.y, RT.transform.position.z);
            }
            
        } else
        {
            RT.transform.position = new Vector3(RT.transform.position.x, yDefault + Mathf.PingPong(Time.time * speed, PingPongOptimum) - PingPongOptimum / 2f, RT.transform.position.z);
        }
        
    }
}
