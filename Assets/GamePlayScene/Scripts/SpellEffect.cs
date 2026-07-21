using UnityEngine;

public class SpellEffect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.coinCollectSound);
        }

        if (VFXManager.Instance != null)
        {
            VFXManager.Instance.SpawnEffect(VFXManager.Instance.coinPickupFX, transform.position, Quaternion.identity);
        }

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}