using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_2 : MonoBehaviour
{
    public GameObject host;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!host) return;
        transform.position = new Vector3(host.transform.position.x, host.transform.position.y, 0);
    }
}
