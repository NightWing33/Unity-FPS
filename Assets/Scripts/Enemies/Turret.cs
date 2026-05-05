using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float fireRate = 2f;
    [SerializeField] int damage = 2;

    void Start()
    {
        StartCoroutine(FireRoutine());
    }

    void Update()
    {
        turretHead.LookAt(playerTargetPoint);
    }

    IEnumerator FireRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            Projectile newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
            newProjectile.transform.LookAt(playerTargetPoint);
            newProjectile.Init(damage);
        }
    }
}
