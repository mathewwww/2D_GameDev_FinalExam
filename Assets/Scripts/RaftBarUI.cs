using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftBarUI : MonoBehaviour
{
    public float RaftHealth = 100f;
    public float MaxRaftHealth = 100f; 
    public float Width, Height;

    [SerializeField]
    private RectTransform healthBar;

    public void SetMaxRaftHealth(float maxRaftHealth) {
        MaxRaftHealth = maxRaftHealth;
    }

    public void SetRaftHealth(float health) {
        RaftHealth = health;
        float newWidth = (RaftHealth / MaxRaftHealth) * Width;

        healthBar.sizeDelta = new Vector2(newWidth, Height);
    }

}