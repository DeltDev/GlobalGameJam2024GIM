using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 StartPos;

    private void Start()
    {
        StartPos = transform.position;
    }

    private Vector3 GetRoamPos()
    {
        return StartPos + GetRandomPos() * Random.Range(10f, 80f);
    }
    private Vector3 GetRandomPos()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
