using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObjectiveBox : MonoBehaviour
{
    public Vector2 disappearPosition;
    public Vector2 appearPosition;

    public float open_closeDuration = 0.5f;
    public float stayDuration = 5f;
    public float delayBeforeAppearance = 1.2f;


    private RectTransform rectTransform;
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start() {
        rectTransform.anchoredPosition = disappearPosition;
        StartCoroutine(ObjectiveBoxCor());
    }

    private IEnumerator ObjectiveBoxCor() {
        yield return new WaitForSeconds(delayBeforeAppearance);
        rectTransform.DOLocalMove(appearPosition, open_closeDuration).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(open_closeDuration + stayDuration);
        rectTransform.DOLocalMove(disappearPosition, open_closeDuration).SetEase(Ease.InBack);
    }

}
