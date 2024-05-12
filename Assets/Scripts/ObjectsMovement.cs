using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoMoveLeft : MonoBehaviour
{
    public float initialMoveSpeed = 5f; 
    public float moveSpeedIncrement = 5f; 
    public float moveSpeedChangeInterval = 50f; 
    public float maxMoveSpeed = 15f; 

    private float currentMoveSpeed;

    void Start()
    {
        currentMoveSpeed = initialMoveSpeed;
        StartCoroutine(ChangeMoveSpeedOverTime());
    }

    void Update()
    {
        transform.Translate(Vector3.left * currentMoveSpeed * Time.deltaTime);
    }

    private IEnumerator ChangeMoveSpeedOverTime()
    {
        yield return new WaitForSeconds(moveSpeedChangeInterval);

        while (true)
        {
            currentMoveSpeed += moveSpeedIncrement; 
            currentMoveSpeed = Mathf.Clamp(currentMoveSpeed, initialMoveSpeed, maxMoveSpeed); 

            yield return new WaitForSeconds(moveSpeedChangeInterval); 
        }
    }
}
