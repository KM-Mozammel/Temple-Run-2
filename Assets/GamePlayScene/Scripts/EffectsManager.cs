using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    [Header("Dependencies")]
    public PlayerController player;
    public Transform playerTransform;

    [Header("Speed Settings")]
    [Tooltip("প্রতি কত মিটার পর পর স্পিড বাড়বে")]
    public float speedIncreaseMilestone = 500f;
    [Tooltip("প্রতি মাইলস্টোনে কতটুকু স্পিড বাড়বে")]
    public float speedMultiplier = 2f;
    [Tooltip("সর্বোচ্চ কত স্পিড পর্যন্ত পৌঁছাতে পারবে")]
    public float maxSpeed = 30f;

    [Header("Environment Trigger")]
    [Tooltip("কত মিটার পর আকাশ এবং ডাইনোসর মেকানিক্স চালু হবে")]
    public float environmentChangeMilestone = 1000f;
    public Material galaxySkybox; // ইনস্পেক্টর থেকে রাতের গ্যালাক্সি স্কাইবক্স ম্যাটেরিয়াল দিন

    [Header("Dinosaur Settings")]
    public GameObject dinosaurPrefab; // ডাইনোসর মডেলের প্রিফ্যাব
    public float spawnInterval = 12f; // ১০-১৫ সেকেন্ডের মাঝামাঝি (১২ সেকেন্ড)

    private float nextSpeedMilestone;
    private bool isEnvironmentChanged = false;
    private float dinoTimer = 0f;
    private float startZ;

    void Start()
    {
        if (playerTransform != null)
        {
            startZ = playerTransform.position.z;
        }
        nextSpeedMilestone = speedIncreaseMilestone;
    }

    void Update()
    {
        if (playerTransform == null || player == null) return;

        // বর্তমান অতিক্রান্ত দূরত্ব হিসাব
        float currentDistance = playerTransform.position.z - startZ;

        // ---- ১. ৫০০ মিটার পর পর গতি বৃদ্ধি লজিক ----
        if (currentDistance >= nextSpeedMilestone && player.forwardSpeed > 0)
        {
            player.forwardSpeed += speedMultiplier;
            if (player.forwardSpeed > maxSpeed)
            {
                player.forwardSpeed = maxSpeed;
            }
            nextSpeedMilestone += speedIncreaseMilestone;
        }

        // ---- ২. ১০০০ মিটার পর গ্যালাক্সি স্কাইবক্স লজিক ----
        if (currentDistance >= environmentChangeMilestone && !isEnvironmentChanged)
        {
            TriggerEnvironmentChange();
        }

        // ---- ৩. ডাইনোসর স্পনিং টাইমার লজিক ----
        if (isEnvironmentChanged && dinosaurPrefab != null)
        {
            dinoTimer += Time.deltaTime;
            if (dinoTimer >= spawnInterval)
            {
                dinoTimer = 0f;
                SpawnTwoDinosaurs();
            }
        }
    }

    void TriggerEnvironmentChange()
    {
        isEnvironmentChanged = true;
        if (galaxySkybox != null)
        {
            RenderSettings.skybox = galaxySkybox;
        }
    }

    void SpawnTwoDinosaurs()
    {
        // প্লেয়ারের পজিশন থেকে কিছুটা সামনে এবং আকাশে স্পন করা
        float spawnAheadZ = playerTransform.position.z + 50f; 
        float skyHeight = 25f; // আকাশ বরাবর উচ্চতা

        // প্রথম ডাইনোসর (বাম থেকে ডানে যাবে)
        Vector3 pos1 = new Vector3(-30f, skyHeight, spawnAheadZ);
        GameObject dino1 = Instantiate(dinosaurPrefab, pos1, Quaternion.Euler(0, 90, 0));
        dino1.AddComponent<DinoFlyer>().Initialize(Vector3.right * 15f, 6f);

        // দ্বিতীয় ডাইনোসর (ডান থেকে বামে যাবে, সামান্য ব্যবধানে)
        Vector3 pos2 = new Vector3(30f, skyHeight + 3f, spawnAheadZ + 10f);
        GameObject dino2 = Instantiate(dinosaurPrefab, pos2, Quaternion.Euler(0, -90, 0));
        dino2.AddComponent<DinoFlyer>().Initialize(Vector3.left * 15f, 6f);
    }
}

// ডাইনোসরকে আকাশে সচল রাখার জন্য একটি ছোট হেল্পার ক্লাস
public class DinoFlyer : MonoBehaviour
{
    private Vector3 moveDirection;
    private float lifeTime;

    public void Initialize(Vector3 direction, float duration)
    {
        moveDirection = direction;
        lifeTime = duration;
        Destroy(gameObject, lifeTime); // নির্দিষ্ট সময় পর মেমোরি থেকে ডিলিট
    }

    void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime, Space.World);
    }
}