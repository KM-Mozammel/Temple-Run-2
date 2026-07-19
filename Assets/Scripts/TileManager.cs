using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    [Header("Prefabs & References")]
    public GameObject tilePrefab;              
    public GameObject[] obstaclePrefabs;       
    public Transform playerTransform;          
    
    [Header("Grass Settings")]
    public GameObject grassPrefab;             
    [Tooltip("কতটি টাইল পর পর ঘাস স্পন হবে? (যেমন: ৩টি টাইল = ৯০ মিটার)")]
    public int spawnGrassEveryNTiles = 3;      // ৩টি টাইল পর পর ঘাস তৈরি হবে
    private int tileCounter = 0;               // টাইল কাউন্ট করার জন্য ট্র্যাক রকার

    public float minX_Left = -8f;              
    public float maxX_Left = -3.5f;            
    public float minX_Right = 3.5f;            
    public float maxX_Right = 8f;              

    [Header("Tile Settings")]
    private float spawnZ = 0.0f;               
    private float tileLength = 30.0f;          
    private int amnTilesOnScreen = 5;          
    private float safeZone = 35.0f;            

    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
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
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile(true);
            DeleteTile();
        }
    }

    private void SpawnTile(bool spawnObstacle)
    {
        GameObject go = Instantiate(tilePrefab, transform.forward * spawnZ, transform.rotation);
        activeTiles.Add(go);

        tileCounter++; // নতুন টাইল তৈরি হলেই কাউন্টার ১ বাড়বে

        // ---- ঘাস জেনারেট করার অপ্টিমাইজড লজিক ----
        // প্রতি ৩ বা ৪টি টাইল (প্রায় ১০০ মিটার) পর পর শুধুমাত্র ১টি ঘাস তৈরি হবে
        if (grassPrefab != null && tileCounter >= spawnGrassEveryNTiles)
        {
            tileCounter = 0; // কাউন্টার রিসেট

            // র্যান্ডমলি সিলেক্ট করা হবে ঘাসটি বামে নাকি ডানে বসবে (১টি ঘাস)
            float randomX = 0f;
            if (Random.Range(0, 2) == 0)
            {
                randomX = Random.Range(minX_Left, maxX_Left); // বামে
            }
            else
            {
                randomX = Random.Range(minX_Right, maxX_Right); // ডানে
            }

            float randomZ = Random.Range(spawnZ, spawnZ + tileLength);
            Vector3 grassPosition = new Vector3(randomX, grassPrefab.transform.position.y, randomZ);

            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            GameObject spawnedGrass = Instantiate(grassPrefab, grassPosition, randomRotation);

            // টাইলের চাইল্ড করা হলো যেন ডিলিট হয়ে যায়
            spawnedGrass.transform.SetParent(go.transform);
        }

        // ---- বাধা তৈরি করার লজিক ----
        if (spawnObstacle && obstaclePrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            int randomPlacement = Random.Range(0, 3);
            int[] placement= {-2, 2, 0}; 
            GameObject obstacleToSpawn = obstaclePrefabs[randomIndex];

            Vector3 spawnPosition = new Vector3(
                placement[randomPlacement], 
                obstacleToSpawn.transform.position.y, 
                spawnZ + (tileLength / 2f)
            );

            GameObject spawnedObstacle = Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);
            spawnedObstacle.transform.SetParent(go.transform);
        }

        spawnZ += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}