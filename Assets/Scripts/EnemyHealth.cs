using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject ExplosionVFX;
    [SerializeField] int startingHealth = 3;
    
    int currentHealth;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        Vector3 spawnPos = transform.position;

        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            spawnPos = col.bounds.center;
        }
        else
        {
            Renderer rend = GetComponentInChildren<Renderer>();
            if (rend != null)
            {
                spawnPos = rend.bounds.center;
            }
        }

        Instantiate(ExplosionVFX, spawnPos, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
