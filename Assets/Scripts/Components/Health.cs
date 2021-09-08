using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float currentHealth;

    public bool isAlive;
    public float invulnerabilityAfterHitInSeconds = 0.5f;
    public bool isVulnerable;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        isAlive = true;
        isVulnerable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(float amount)
    {
        if(!isVulnerable)
        {
            return;
        }

        currentHealth -= amount;
        StartCoroutine(TemporaryInvulnerability());
        
        if(currentHealth <= 0)
        {
            isAlive = false;
            Debug.Log($"{gameObject.name} is dead!");
        }
    }

    IEnumerator TemporaryInvulnerability()
    {
        isVulnerable = false;
        yield return new WaitForSeconds(invulnerabilityAfterHitInSeconds);
        isVulnerable = true;
    }
}
