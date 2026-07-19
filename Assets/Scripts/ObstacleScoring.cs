using UnityEngine;

public class ObstacleScoring : MonoBehaviour
{
    public enum ObstacleType { Low, High }
    
    [Header("Obstacle Settings")]
    public ObstacleType typeOfObstacle; // Inspector থেকে Low বা High সিলেক্ট করার জন্য
    
    private int obstacleLane; // অবস্ট্যাকলটি কোন লেনে আছে (0 = Left, 1 = Middle, 2 = Right)
    private bool pointAwarded = false; // এক বাধার জন্য যেন একাধিকবার পয়েন্ট না আসে

    void Start()
    {
        // অবস্ট্যাকলের X পজিশন দেখে তার লেন নির্ধারণ করা (আপনার লেনের ডিসট্যান্স ২ অনুযায়ী)
        float posX = transform.position.x;
        
        if (posX < -1f) obstacleLane = 0;      // Left Lane
        else if (posX > 1f) obstacleLane = 2;   // Right Lane
        else obstacleLane = 1;                  // Middle Lane
    }

    void Update()
    {
        // যদি অলরেডি এই বাধা চেক করা হয়ে থাকে, তবে আর কাজ করবে না
        if (pointAwarded) return;

        // প্লেয়ার অবজেক্ট খুঁজে নেওয়া
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player == null) return;

        // প্লেয়ার যখন অবস্ট্যাকলের কাছাকাছি বা জাস্ট পার হয়ে যাবে (Z Axis-এ)
        if (player.transform.position.z >= transform.position.z - 0.5f)
        {
            int playerLane = player.CurrentLane; 
            bool playerIsJumping = !player.IsGroundedProperty; 
            bool playerIsSliding = player.IsSlidingProperty; 

            // শর্ত ১: প্লেয়ার আর অবস্ট্যাকল কি একই লেনে আছে?
            if (playerLane == obstacleLane)
            {
                // শর্ত ২: প্লেয়ার কি সঠিক বাধা এড়ানোর নিয়ম মেনেছে?
                if (typeOfObstacle == ObstacleType.Low && playerIsJumping)
                {
                    AwardPoint();
                }
                else if (typeOfObstacle == ObstacleType.High && playerIsSliding)
                {
                    AwardPoint();
                }
                else
                {
                    // একই লেনে ছিল কিন্তু প্লেয়ার সঠিক অ্যাকশন নেয়নি 
                    // (যদিও কোল্ডিশনের কারণে এখানে গেম ওভার হয়ে যাওয়ার কথা, তাও সেফটির জন্য ট্র্যাকিং বন্ধ করা হলো)
                    pointAwarded = true;
                }
            }
            else
            {
                // প্লেয়ার অন্য লেন দিয়ে চলে গেছে (কোনো পয়েন্ট পাবে না)
                pointAwarded = true; 
                Debug.Log("[SCORE] Player passed safely via another lane. No points given.");
            }
        }
    }

    void AwardPoint()
    {
        pointAwarded = true;
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(1);
            Debug.Log("[SCORE] Point added! Correct action in correct lane.");
        }
    }
}