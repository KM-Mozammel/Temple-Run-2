using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager Instance { get; private set; }

    [Header("Particle Prefabs")]
    public GameObject coinPickupFX;
    public GameObject jumpDustFX;
    public GameObject gameOverFX;

    void Awake()
    {
        // Singleton Pattern নিশ্চিত করা
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // সিন চেঞ্জ হলেও যেন নষ্ট না হয়
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// নির্দিষ্ট পজিশনে ইফেক্ট স্পন করার মেথড
    /// </summary>
    public void SpawnEffect(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (prefab != null)
        {
            GameObject fx = Instantiate(prefab, position, rotation);
            // ২ সেকেন্ড পর মেমোরি থেকে অটোমেটিক ডিলিট হবে
            Destroy(fx, 2.0f);
        }
    }
}