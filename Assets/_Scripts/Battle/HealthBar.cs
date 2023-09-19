using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;

    /// <summary>
        /// Actualiza la barra de vida a partir del valor normalizado de la misma  
        /// </summary>
        /// <param name="normalizedValue">Valor de la vida normalizado entre 0 y 1</param>
        public void SetHP(float normalizedValue)
    {
        healthBar.transform.localScale = new Vector3(normalizedValue, 1.0f);
        healthBar.GetComponent<Image>().color = ColorManager.SharedInstance.BarColor(normalizedValue);
    }

    public IEnumerator SetSmoothHP(float normalizedValue)
    {
        var seq = DOTween.Sequence();
        seq.Append(healthBar.transform.DOScaleX(normalizedValue, 1f));
        seq.Join(healthBar.GetComponent<Image>().DOColor(ColorManager.SharedInstance.BarColor(normalizedValue), 1f));
        yield return seq.WaitForCompletion();
    }
}