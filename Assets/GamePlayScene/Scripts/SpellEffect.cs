using UnityEngine;

public class SpellEffect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // This will print the name of ANY object that touches the effect in the Console
        Debug.Log("Spell Effect hit by: " + other.gameObject.name + " with Tag: " + other.tag);

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}