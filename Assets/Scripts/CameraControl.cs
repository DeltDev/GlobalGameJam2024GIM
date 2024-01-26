using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    #region Fields
    public Transform PlayerPosition;
    [SerializeField] private float smoothSpeed = 0.25f;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 velocity = Vector3.zero;
    #endregion
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 NewPosition = PlayerPosition.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, NewPosition, ref velocity, smoothSpeed);
    }
}
