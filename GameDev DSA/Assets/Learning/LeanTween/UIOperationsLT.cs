using UnityEngine;
using UnityEngine.UI;

public class UIOperationsLT : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;

    Vector3 firstPos = new Vector3(0f, 0f);
    Vector3 finalPos = new Vector3(-900f, 0f);

    private void Awake()
    {
        rectTransform.anchoredPosition = finalPos;
    }

    private void Start()
    {
        OnPanelInAndOut();
        OnFadePanel();
    }

    public void OnPanelInAndOut()
    {
        var seq = LeanTween.sequence();

        seq.append(LeanTween.move(rectTransform, firstPos, 1.5f).setEase(LeanTweenType.easeInSine));
        seq.append(0.2f);
        seq.append(LeanTween.move(rectTransform, finalPos, 1.5f).setEase(LeanTweenType.easeInSine));
        seq.append(() => Debug.Log("Panel In and Out Completed"));
    }

    public void OnFadePanel()
    {
        CanvasGroup cg = rectTransform.GetComponent<CanvasGroup>();
        cg.blocksRaycasts = false;
        cg.interactable = false;

        if (cg == null)
        {
            cg = rectTransform.gameObject.AddComponent<CanvasGroup>();
            return;
        }

        LeanTween.value(gameObject, cg.alpha, 0f, 1.5f) // from 1 -> 0 alpha in 1.5s
            .setOnUpdate(
                (float val) =>
                {
                    cg.alpha = val;
                }
            );
    }

}