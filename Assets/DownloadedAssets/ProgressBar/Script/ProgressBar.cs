using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]

public class ProgressBar : MonoBehaviour
{
    [Header("Bar Setting")]
    public Color BarColor;   
    public Color BarBackGroundColor;
    public Sprite BarBackGroundSprite;
    
    [Range(1f, 100f)]
    public int Alert = 20;
    public Color BarAlertColor;

    [NonSerialized] public TextMeshPro NameTagText;

    private Image bar, barBackground;
    private float nextPlay;
    private float barValue;
    public float BarValue
    {
        set
        {
            value = Mathf.Clamp(value, 0, 100);
            barValue = value;
            UpdateValue(barValue);
        }
    }

    private void Awake()
    {
        bar = transform.Find("Bar").GetComponent<Image>();
        barBackground = GetComponent<Image>();
        barBackground = transform.Find("BarBackground").GetComponent<Image>();
    }

    private void Start()
    {
        bar.color = BarColor;
        barBackground.color = BarBackGroundColor; 
        barBackground.sprite = BarBackGroundSprite;

        NameTagText = GetComponentInChildren<TextMeshPro>();
    }

    public void SetNameTagText(string text)
    {
        if (NameTagText != null)
        {
            NameTagText.text = text;
        }
    }

    void UpdateValue(float percentage)
    {
        if (bar == null) return;
        bar.fillAmount = percentage;
        bar.color = BarColor;
    }
}
