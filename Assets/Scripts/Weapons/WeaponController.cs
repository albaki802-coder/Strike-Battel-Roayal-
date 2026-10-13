using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] private Camera aimCamera;
    [SerializeField] private float damage = 25f;
    [SerializeField] private float range = 150f;
    [SerializeField] private float shotsPerSecond = 6f;
    [SerializeField] private int magazineSize = 30;
    [SerializeField] private float reloadSeconds = 1.5f;
    [SerializeField] private LayerMask hitMask = ~0;

    public int AmmoInMagazine { get; private set; }
    public int MagazineSize => magazineSize;
    public bool IsReloading { get; private set; }
    public event Action<int, int> AmmoChanged;

    private float nextShotTime;
    private float reloadCompleteTime;

    private void Awake()
    {
        if (aimCamera == null) aimCamera = Camera.main;
        AmmoInMagazine = magazineSize;
        NotifyAmmo();
    }

    private void Update()
    {
        if (IsReloading && Time.time >= reloadCompleteTime)
        {
            IsReloading = false;
            AmmoInMagazine = magazineSize;
            NotifyAmmo();
        }
    }

    // Connect this method to the mobile fire button's PointerDown/hold behaviour.
    public void Fire()
    {
        if (IsReloading || Time.time < nextShotTime) return;
        if (AmmoInMagazine <= 0) { Reload(); return; }
        if (aimCamera == null) return;

        nextShotTime = Time.time + 1f / Mathf.Max(0.1f, shotsPerSecond);
        AmmoInMagazine--;
        NotifyAmmo();

        if (Physics.Raycast(aimCamera.transform.position, aimCamera.transform.forward,
            out RaycastHit hit, range, hitMask, QueryTriggerInteraction.Ignore))
        {
            HealthSystem health = hit.collider.GetComponentInParent<HealthSystem>();
            if (health != null) health.TakeDamage(damage);
        }
    }

    public void Reload()
    {
        if (IsReloading || AmmoInMagazine >= magazineSize) return;
        IsReloading = true;
        reloadCompleteTime = Time.time + reloadSeconds;
    }

    private void NotifyAmmo() => AmmoChanged?.Invoke(AmmoInMagazine, magazineSize);
}
