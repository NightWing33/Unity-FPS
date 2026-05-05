using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    [SerializeField] GameObject projectileHitVFX;

    Rigidbody rb;

    int damage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    public void Init(int damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 spawnPos = transform.position;

        if (other != null)
        {
            // Prefer the hit object's bounds center so VFX appears centered on large targets
            spawnPos = other.bounds.center;
        }
        else
        {
            Renderer rend = GetComponentInChildren<Renderer>();
            if (rend != null)
            {
                spawnPos = rend.bounds.center;
            }
        }

        Instantiate(projectileHitVFX, spawnPos, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
