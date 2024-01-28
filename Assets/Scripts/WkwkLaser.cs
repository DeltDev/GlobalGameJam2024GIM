using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WkwkLaser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject WkwkLaserPrefab;
    [SerializeField] private Transform ProjectileSpawnPosition;
    [SerializeField] private float AttackCooldownTime;
    [SerializeField] private float ProjectileDespawnTime;
    [SerializeField] private int TickNumber;
    [SerializeField] private float TickSpeed;
    private AudioManager audioManager;
    private TopDownController TopDown;
    private bool canWkwkAttack;

    [SerializeField] private Image cooldownRadialProgress;
    void Start()
    {
        canWkwkAttack = true;
        TopDown = GetComponent<TopDownController>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canWkwkAttack)
        {
            //WkwkAttack();
            canWkwkAttack = false;
            TopDown.disableRotation= true;
            audioManager.PlaySound("WKWKWKSFX");
            StartCooldownUI(AttackCooldownTime);
            StartCoroutine(AttackCooldown(AttackCooldownTime, TickSpeed, TickNumber));
        }
    }

    IEnumerator AttackCooldown(float CooldownTime, float TickSpeed, int TickNumber)
    {
        for(int i = 0; i < TickNumber; i++)
        {
            yield return new WaitForSeconds(TickSpeed);
            GameObject laser = Instantiate(WkwkLaserPrefab, ProjectileSpawnPosition.position, transform.rotation);
            Camera.main.transform.DOShakePosition(ProjectileDespawnTime + 1f, new Vector3(0.1f, 0.0075f, 0)).SetEase(Ease.OutSine);
            StartCoroutine(DespawnProjectile(ProjectileDespawnTime, laser));
        }
        TopDown.disableRotation = false;
        yield return new WaitForSeconds(CooldownTime);
        
        canWkwkAttack = true;
    }

    IEnumerator DespawnProjectile(float DespawnTime, GameObject laser)
    {
        yield return new WaitForSeconds(DespawnTime);
        
        Destroy(laser);
    }

    void StartCooldownUI(float cooldownTime)
    {
        cooldownRadialProgress.fillAmount = 0;
        cooldownRadialProgress.DOFillAmount(1, cooldownTime).SetEase(Ease.Linear);
    }

}
