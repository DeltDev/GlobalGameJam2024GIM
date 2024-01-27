using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TouchGrassAttack : MonoBehaviour
{
    [SerializeField] private float TouchGrassDurationTime;
    [SerializeField] private float TouchGrassCooldownTime;
    [SerializeField] private GameObject GrassHitbox;
    [SerializeField] private Animator animator;
    private bool canGrassAttack;

    private void Start()
    {
        canGrassAttack= true;
        GrassHitbox.SetActive(false);
    }
    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.G) && canGrassAttack)
            {
                GrassHitbox.SetActive(true);
                canGrassAttack = false;
                StartCoroutine(TouchGrassDuration(TouchGrassDurationTime));
                StartCoroutine(TouchGrassCooldown(TouchGrassCooldownTime));
            }
        }
        
    }
    IEnumerator TouchGrassDuration(float Duration)
    {
        yield return new WaitForSeconds(Duration);
        animator.SetTrigger("CloseGrass");
        yield return new WaitForSeconds(0.5f);
        GrassHitbox.SetActive(false);
    }
    IEnumerator TouchGrassCooldown(float CooldownTime)
    {
        yield return new WaitForSeconds(CooldownTime);
        canGrassAttack= true;
    }
}
