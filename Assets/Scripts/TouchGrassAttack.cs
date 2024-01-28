using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TouchGrassAttack : MonoBehaviour
{
    [SerializeField] private float TouchGrassDurationTime;
    [SerializeField] private float TouchGrassCooldownTime;
    [SerializeField] private GameObject GrassHitbox;
    [SerializeField] private Animator animator;
    private bool canGrassAttack;
    private AudioManager audioManager;
    [SerializeField] private Image cooldownRadialProgress;
    private void Start()
    {
        canGrassAttack= true;
        GrassHitbox.SetActive(false);
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();    
    }
    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.G) && canGrassAttack)
            {
                StartCooldownUI(TouchGrassCooldownTime);
                GrassHitbox.SetActive(true);
                canGrassAttack = false;
                audioManager.PlaySound("GrassSFX");
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

    void StartCooldownUI(float cooldownTime)
    {
        cooldownRadialProgress.fillAmount = 0;
        cooldownRadialProgress.DOFillAmount(1, cooldownTime).SetEase(Ease.Linear);
    }

}
