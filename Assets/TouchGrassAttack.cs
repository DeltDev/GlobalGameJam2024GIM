using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TouchGrassAttack : MonoBehaviour
{
    [SerializeField] private float TouchGrassDurationTime;
    [SerializeField] private float TouchGrassCooldownTime;
    [SerializeField] private GameObject GrassHitbox;
    private bool canGrassAttack;

    private void Start()
    {
        canGrassAttack= true;
        GrassHitbox.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && canGrassAttack)
        {
            GrassHitbox.SetActive(true);
            canGrassAttack= false;
            StartCoroutine(TouchGrassDuration(TouchGrassDurationTime));
            StartCoroutine(TouchGrassCooldown(TouchGrassCooldownTime));
        }
    }
    IEnumerator TouchGrassDuration(float Duration)
    {
        yield return new WaitForSeconds(Duration);
        GrassHitbox.SetActive(false);
    }
    IEnumerator TouchGrassCooldown(float CooldownTime)
    {
        yield return new WaitForSeconds(CooldownTime);
        canGrassAttack= true;
    }
}
