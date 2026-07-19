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
        if (pointAwarded) return;

        PlayerController player = FindObjectOfType<PlayerController>();
        if (player == null) return;

        // প্লেয়ার যখন অবস্ট্যাকলের কাছাকাছি আসবে
        if (player.transform.position.z >= transform.position.z - 0.5f)
        {
            int playerLane = player.CurrentLane;
            bool playerIsJumping = !player.IsGroundedProperty;
            bool playerIsSliding = player.IsSlidingProperty;

            // শর্ত ১: প্লেয়ার আর অবস্ট্যাকল একই লেনে আছে কিনা
            if (playerLane == obstacleLane)
            {
                // শর্ত ২: ট্যাগ অনুযায়ী সঠিক মেকানিক্স চেক করা হচ্ছে
                if (gameObject.CompareTag("LowerObstacle") && playerIsJumping)
                {
                    AwardPoint();
                }
                else if (gameObject.CompareTag("HigherObstacle") && playerIsSliding)
                {
                    AwardPoint();
                }
                else
                {
                    // সঠিক অ্যাকশন না নিলে ট্র্যাকিং বন্ধ (ধাক্কা খেয়ে গেম ওভার হবে)
                    pointAwarded = true;
                }
            }
            else
            {
                // অন্য লেন দিয়ে নিরাপদে চলে গেলে নো পয়েন্ট
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