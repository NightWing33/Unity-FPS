using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] float bulletMarkOffset = 0.01f;
    [SerializeField] LayerMask interactionLayers;

    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFlash.Play();
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers, QueryTriggerInteraction.Ignore))
        {
            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);
            SpawnBulletMark(weaponSO, hit);
            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);     
        }
    }

    void SpawnBulletMark(WeaponSO weaponSO, RaycastHit hit)
    {
        if (weaponSO.BulletMarkPrefab == null) return;

        Vector3 spawnPosition = hit.point + hit.normal * bulletMarkOffset;
        Quaternion spawnRotation = Quaternion.LookRotation(-hit.normal);
        GameObject bulletMark = Instantiate(weaponSO.BulletMarkPrefab, spawnPosition, spawnRotation);
        bulletMark.transform.SetParent(hit.collider.transform, true);
    }
}