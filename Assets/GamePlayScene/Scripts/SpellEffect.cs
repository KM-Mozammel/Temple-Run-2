using UnityEngine;

public class SpellEffect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // This will print the name of ANY object that touches the effect in the Console
        Debug.Log("Spell Effect hit by: " + other.gameObject.name + " with Tag: " + other.tag);

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