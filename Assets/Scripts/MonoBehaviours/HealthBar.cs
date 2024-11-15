using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [HideInInspector]
    public Player character;
    public Image meterImage;
    public Text hpText;
    void Start()
    {
        character.hitPoints.value = 0;
    }
    void Update()
    {
        if (character != null)
        {
            meterImage.fillAmount = character.hitPoints.value / character.maxHitPoints;
            hpText.text = "HP:" + (meterImage.fillAmount * 100);
        }
    }
}