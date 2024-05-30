using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class LoadBar : MonoBehaviour
{
    [SerializeField] private GameObject barPanel, bar, cookPanel;
    [SerializeField] private int loadTime;

    private void Awake()
    {
        ResetBar();
    }

    public void AnimateBar()
    {
        if (IngredientsUI.Instance.currentSelect == null) return;

        Destroy(IngredientsUI.Instance.currentSelect);

        barPanel.SetActive(true);
        cookPanel.SetActive(false);

        PlayerMovement.Instance.canMove = true;

        bar.GetComponent<RectTransform>().localScale = new Vector3(0, 0.7f, 1);
        LeanTween.scaleX(bar, 1, loadTime);

        StartCoroutine(CookingProccess());
    }

    IEnumerator CookingProccess()
    {
        yield return new WaitForSeconds(loadTime);
        Debug.Log("Finish Cooking!");
        ResetBar();
    }

    private void ResetBar()
    {
        barPanel.SetActive(false);
        bar.GetComponent<RectTransform>().localScale = new Vector3(0, 0.7f, 1);
    }
}
