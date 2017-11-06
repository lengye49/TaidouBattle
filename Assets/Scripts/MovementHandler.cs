using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MovementHandler : MonoBehaviour {

    private float timeOfMovement = 0.5f;
    private float timeWaitToShow = 0.2f;

    /// <summary>
    /// Shows a panel.
    /// </summary>
    /// <param name="newPanel">New panel.</param>
    public void ShowPanel(GameObject newPanel){
        newPanel.SetActive(true);
        newPanel.transform.localScale = Vector3.zero;
        newPanel.transform.DOBlendableScaleBy(Vector3.one, timeOfMovement);
    }
        
    /// <summary>
    /// Hides a panel.
    /// </summary>
    /// <param name="oldPanel">Old panel.</param>
    public void HidePanel(GameObject oldPanel){
        oldPanel.transform.DOBlendableScaleBy(-Vector3.one, timeOfMovement);
        oldPanel.SetActive(false);
    }

    /// <summary>
    /// Hides an old panel and show a new one.
    /// </summary>
    /// <param name="oldPanel">Old panel.</param>
    /// <param name="newPanel">New panel.</param>
    public void ChangePanel(GameObject oldPanel,GameObject newPanel){
        HidePanel(oldPanel);
        StartCoroutine(WaitAndShowNewPanel(newPanel));
    }

    IEnumerator WaitAndShowNewPanel(GameObject newPanel){
        yield return new WaitForSeconds(timeWaitToShow);
        ShowPanel(newPanel);
    }
        
}
