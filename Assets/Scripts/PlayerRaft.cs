using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaft : MonoBehaviour
{
    public float RaftHealth = 100f; 
    public float MaxRaftHealth = 100f;
    public float decreaseRate = 1f; 

    [SerializeField]
    private RaftBarUI healthBar;

    void Start()
    {
        healthBar.SetMaxRaftHealth(MaxRaftHealth);
        StartCoroutine(DecreaseHealthOverTime());
    }

    void Update()
    {
        if (RaftHealth == 0f)
        {
            // Time.timeScale = 0;
        }
    }

    public void SetRaftHealth(float rafthealthChange)
    {
        RaftHealth += rafthealthChange;
        RaftHealth = Mathf.Clamp(RaftHealth, 0, MaxRaftHealth);

        healthBar.SetRaftHealth(RaftHealth);
    }

    private IEnumerator DecreaseHealthOverTime()
    {
        while (RaftHealth > 0)
        {
            yield return new WaitForSeconds(1f); 
            SetRaftHealth(-decreaseRate);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            SetRaftHealth(-10f);
        }

        if (collision.gameObject.CompareTag("Scrap"))
        {
            SetRaftHealth(10f);
        }
    }
}
