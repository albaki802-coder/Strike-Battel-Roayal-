using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class TargetDummy : MonoBehaviour
{
    [SerializeField] private GameObject visualRoot;
    [SerializeField] private float respawnSeconds = 3f;

    private HealthSystem health;
    private Collider[] targetColliders;
    private Renderer[] targetRenderers;
    private float respawnAt;
    private bool waitingToRespawn;

    private void Awake()
    {
        health = GetComponent<HealthSystem>();
        targetColliders = GetComponentsInChildren<Collider>();
        targetRenderers = (visualRoot != null ? visualRoot : gameObject).GetComponentsInChildren<Renderer>();
        health.Died += OnDied;
    }

    private void Update()
    {
        if (!waitingToRespawn || Time.time < respawnAt) return;
        waitingToRespawn = false;
        health.RestoreForRespawn();
        SetVisible(true);
    }

    private void OnDied()
    {
        waitingToRespawn = true;
        respawnAt = Time.time + respawnSeconds;
        SetVisible(false);
    }

    private void SetVisible(bool visible)
    {
        foreach (Collider c in targetColliders) if (c != null) c.enabled = visible;
        foreach (Renderer r in targetRenderers) if (r != null) r.enabled = visible;
    }

    private void OnDestroy()
    {
        if (health != null) health.Died -= OnDied;
    }
}
