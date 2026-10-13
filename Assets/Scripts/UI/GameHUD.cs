using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private HealthSystem playerHealth;
    [SerializeField] private WeaponController weapon;
    [SerializeField] private Text healthText;
    [SerializeField] private Text ammoText;

    private void OnEnable()
    {
        if (playerHealth != null) playerHealth.HealthChanged += UpdateHealth;
        if (weapon != null) weapon.AmmoChanged += UpdateAmmo;
        Refresh();
    }

    private void OnDisable()
    {
        if (playerHealth != null) playerHealth.HealthChanged -= UpdateHealth;
        if (weapon != null) weapon.AmmoChanged -= UpdateAmmo;
    }

    private void Refresh()
    {
        if (playerHealth != null) UpdateHealth(playerHealth.CurrentHealth, playerHealth.MaxHealth);
        if (weapon != null) UpdateAmmo(weapon.AmmoInMagazine, weapon.MagazineSize);
    }

    private void UpdateHealth(float current, float max)
    {
        if (healthText != null) healthText.text = $"HP: {Mathf.CeilToInt(current)}/{Mathf.CeilToInt(max)}";
    }

    private void UpdateAmmo(int current, int max)
    {
        if (ammoText != null) ammoText.text = $"AMMO: {current}/{max}";
    }
}
