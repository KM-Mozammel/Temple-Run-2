using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    [Header("Prefabs & References")]
    public GameObject tilePrefab;              // রাস্তার বা টাইলের প্রিফ্যাব
    public GameObject[] obstaclePrefabs;       // বাধাগুলোর প্রিফ্যাব (এখানে Low এবং High দুটি প্রিফ্যাবই ড্রপ করবেন)
    public Transform playerTransform;          // প্লেয়ারের ট্রান্সফর্ম রেফারেন্স

    [Header("Tile Settings")]
    private float spawnZ = 0.0f;               // পরবর্তী টাইলটি কোন Z পজিশনে তৈরি হবে
    private float tileLength = 30.0f;          // একটি টাইলের দৈর্ঘ্য
    private int amnTilesOnScreen = 5;          // স্ক্রিনে একসাথে কয়টি টাইল থাকবে
    private float safeZone = 35.0f;            // প্লেয়ার পেছনের টাইল থেকে কতদূর গেলে নতুন টাইল তৈরি হবে

    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        // গেমের শুরুতে স্ক্রিনে টাইলগুলো তৈরি করা
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            // গেমের একদম শুরুর ১ নম্বর ফাস্ট টাইলে আমরা কোনো বাধা দেব না, যাতে প্লেয়ার একটু সেট হওয়ার সময় পায়
            if (i == 0)
            {
                SpawnTile(false); 
            }
            else
            {
                SpawnTile(true);
            }
        }
    }

    void Update()
    {
        // প্লেয়ার যখন নির্দিষ্ট দূরত্ব সামনে যাবে, নতুন টাইল তৈরি হবে এবং পেছনেরটা ডিলিট হবে
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile(true);
            DeleteTile();
        }
    }

    private void SpawnTile(bool spawnObstacle)
    {
        // নতুন টাইল তৈরি করা
        GameObject go = Instantiate(tilePrefab, transform.forward * spawnZ, transform.rotation);
        activeTiles.Add(go);

        // যদি এই টাইলে বাধা তৈরি করতে বলা হয় এবং আমাদের কাছে বাধা থাকে
        if (spawnObstacle && obstaclePrefabs.Length > 0)
        {
            // র্যান্ডমলি যেকোনো একটি বাধা (Low বা High) সিলেক্ট করা
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            GameObject obstacleToSpawn = obstaclePrefabs[randomIndex];

            // বাধাটি টাইলের কোন পজিশনে বসবে (Z axis-এ টাইলের মাঝখান বরাবর এবং Y axis-এ বাধার নিজস্ব হাইট অনুযায়ী)
            Vector3 spawnPosition = new Vector3(
                0, 
                obstacleToSpawn.transform.position.y, 
                spawnZ
            );

            // বাধাটি তৈরি করা এবং সেটিকে টাইলের চাইল্ড (Child) বানিয়ে দেওয়া, যাতে টাইল ডিলিট হলে বাধাও ডিলিট হয়ে যায়
            GameObject spawnedObstacle = Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);
            spawnedObstacle.transform.SetParent(go.transform);
        }

        // পরবর্তী টাইলের পজিশন আপডেট করা
        spawnZ += tileLength;
    }

    private void DeleteTile()
    {
        // স্ক্রিনের সবচেয়ে পেছনের টাইলটি মেমোরি থেকে ডিলিট করা
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}