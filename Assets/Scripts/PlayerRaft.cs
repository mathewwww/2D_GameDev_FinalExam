using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaft : MonoBehaviour
{
    public float RaftHealth = 100f;
    public float MaxRaftHealth = 100f;
    public float decreaseRate = 4f;

    [SerializeField]
    private RaftBarUI healthBar;


    public GameObject gameOverCanvas;

    void Start()
    {

        gameOverCanvas.SetActive(false);

        healthBar.SetMaxRaftHealth(MaxRaftHealth);

        StartCoroutine(DecreaseHealthOverTime());
    }

    void Update()
    {

        CheckHealthStatus();
    }

    public void SetRaftHealth(float rafthealthChange)
    {

        RaftHealth += rafthealthChange;
        RaftHealth = Mathf.Clamp(RaftHealth, 0, MaxRaftHealth);

       
        healthBar.SetRaftHealth(RaftHealth);


        CheckHealthStatus();
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

        if (collision.CompareTag("Rock"))
        {
            Debug.Log("Collided with Rock!");
            SetRaftHealth(-10);
        }


        if (collision.CompareTag("Scrap"))
        {
            Debug.Log("Collided with Scrap!");
            SetRaftHealth(15f);
        }
    }

    private void CheckHealthStatus()
    {

        if (RaftHealth <= 0f && !gameOverCanvas.activeSelf)
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}