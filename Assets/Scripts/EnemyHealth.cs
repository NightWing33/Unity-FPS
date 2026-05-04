using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject bomberExplosionVFX;
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
        Instantiate(bomberExplosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
