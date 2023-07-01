using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public int maxHealth;
    public Gradient gradient;
    public Image fill;
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    void Start()
    {
        SetHealth(ScoreManager.health);
    }
    void Update()
    {
        SetHealth(ScoreManager.health);
    }
}
