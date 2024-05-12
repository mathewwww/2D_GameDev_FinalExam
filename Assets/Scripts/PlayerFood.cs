using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFood : MonoBehaviour
{
    public float Health = 100f; 
    public float MaxHealth = 100f;
    public float decreaseRate = 1f; 

    [SerializeField]
    private FoodBarUI healthBar;

    void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
        StartCoroutine(DecreaseHealthOverTime());
    }

    void Update()
    {
    }

    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        healthBar.SetHealth(Health);
    }

    private IEnumerator DecreaseHealthOverTime()
    {
        while (Health > 0)
        {
            yield return new WaitForSeconds(1f); 
            SetHealth(-decreaseRate);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            SetHealth(-20f);
        }

        if (collision.gameObject.CompareTag("Food"))
        {
            SetHealth(10f);
        }
    }
}