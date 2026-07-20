### সাধারণ পরিচিতি (General Information):
    গেমের নাম: অবিরাম দৌড়।
    গেমের ধরণ (Genre): এন্ডলেস রানার (Temple Run-এর মতো)।
    আর্ট স্টাইল (Art Style): রিয়ালিস্টিক (Realistic)। 

    গেমের গল্প (Game Story): 
        এক প্রাচীন মন্দিরের লুকানো ধন চুরি করার পর, মন্দিরের রক্ষী দানব আপনার পিছু নেয়। এখন আপনার সামনে একটাই রাস্তা, তা হলো অবিরাম দৌড়ে সেই দানবের হাত থেকে নিজের জীবন বাঁচানো।

    গেমের নিয়ম ও স্কোরিং সিস্টেম (Rules & Scoring): 
    * মূল নিয়ম: প্লেয়ারকে অবিরাম সামনের দিকে দৌড়াতে হবে এবং মন্দিরের রক্ষী দানব থেকে বাঁচতে হবে। সামনে আসা বিভিন্ন বাধা যেমন পাথর বা গাছের শিকড় এড়িয়ে চলতে হবে।
        * নিচু বাধা (Low Obstacle): যেমন মাটির কাছাকাছি থাকা পাথর বা গাছের শিকড়। এগুলোকে অতিক্রম করার জন্য প্লেয়ারকে অবশ্যই **লাফ (Jump)** দিতে হবে।
        * উঁচু বাধা (High Obstacle): যেমন শূন্যে ভাসমান প্রাচীন মন্দিরের পিলার বা গাছের নিচু ডাল। এগুলোর নিচ দিয়ে পার হওয়ার জন্য প্লেয়ারকে অবশ্যই মাটির সাথে **স্লাইড (Slide)** করতে হবে।

        স্কোরিং সিস্টেম: প্লেয়ারের মোট স্কোর দুটি মিটার রয়েচে-
            ১. মন্দিরে কতখানি দূরত্ব (Distance) অতিক্রম করা হয়েছে। এটি ডিস্টেন্স।
            ২. পথ থেকে তিনি কতগুলি অবস্টাকল অতিক্রম করেছেন। এটাই স্কোর।
            ** যত বেশি দূরত্ব অতিক্রম করা হবে এবং যত বেশি অবস্টাকল অতিক্রম করা হয়েচে, তত বাড়বে।

        স্কোরিং শর্তাবলী (Scoring Logic): প্লেয়ার কোনো একটি বাধা অতিক্রম করলে স্কোর **+১** হবে কিনা, তা সম্পূর্ণভাবে ৩টি নির্দিষ্ট শর্তের ওপর নির্ভর করছে:
            *লেন ম্যাচিং (Same Lane Check):** প্লেয়ার ঠিক যে লেনে দৌড়াচ্ছে, অবস্ট্যাকলটিও যদি ঠিক **একই লেনে** থাকে, তবেই কেবল স্কোর কাউন্টের হিসাব শুরু হবে।
            *সঠিক মেকানিক্স অ্যাকশন (Correct Action Check): প্লেয়ার যদি লো-অবস্ট্যাকলের লেনে থাকে, তবে তাকে **জাম্প** করে সেটি পার হতে হবে। তাহলেই স্কোর **+১** হবে।
            *প্লেয়ার যদি হাই-অবস্ট্যাকলের লেনে থাকে, তবে তাকে **স্লাইড** করে সেটি পার হতে হবে। তাহলেই স্কোর **+১** হবে।

            * ভিন্ন লেনের ক্ষেত্রে (Different Lane = No Points): অবস্ট্যাকল যদি মিডল লেনে থাকে আর প্লেয়ার যদি আগে থেকেই রাইট লেনে (বা লেফট লেনে) থাকে, তবে প্লেয়ারকে কোনো জাম্প বা স্লাইড করতে হচ্ছে না—সে অনায়াসে পাশ দিয়ে চলে যাচ্ছে। এই ক্ষেত্রে প্লেয়ার নিরাপদে বেঁচে গেলেও **কোনো স্কোর (No Point) পাবে না।

    গেমের কন্ট্রোলস (Game Controls):
        
        বাঁ-দিকে সোয়াইপ (Swipe Left): প্লেয়ার বাঁ-দিকে যাবে (Lane change)।
        ডানদিকে সোয়াইপ (Swipe Right): প্লেয়ার ডানদিকে যাবে (Lane change)।
        ওপরের দিকে সোয়াইপ (Swipe Up): প্লেয়ার লাফ দেবে (Jump)।
        নিচের দিকে সোয়াইপ (Swipe Down): প্লেয়ার মাটির সাথে স্লাইড করবে (Slide)।

    বাধা বা অবস্ট্যাকল ডিজাইন (Obstacle Design): গেমে মূলত **দুই ধরণের** বাধা বা অবস্ট্যাকল আছে এবং সেগুলো ৩টি লেনের (Left, Middle, Right) যেকোনো একটিতে প্রসিডিউরালভাবে জেনারেট হয় ।
        নিচু বাধা (Low Obstacles): যেমন বড় পাথর বা গাছের শিকড়, যেগুলোর ওপর দিয়ে প্লেয়ারকে **লাফ (Jump)** দিয়ে পার হতে হবে।
        উंचे বাধা (High Obstacles): যেমন ভেঙে পড়া প্রাচীন মন্দিরের পিলার বা গাছের নিচু ডাল, যেগুলোর নিচ দিয়ে প্লেয়ারকে **স্লাইড (Slide)** করে পার হতে হবে।
        বাঁক (Turns): হঠাৎ আসা ডানে বা বামে যাওয়ার তীক্ষ্ণ মোড়, যেখানে সঠিক সময়ে সোয়াইপ না করলে প্লেয়ার রাস্তা থেকে নিচে পড়ে যাবে বা দেয়ালে ধাক্কা খাবে।

    ইউজার ইন্টারফেস (UI Design): গেম প্লে স্ক্রিনের ওপরের অংশে রিয়াল-টাইমে নিচের বিষয়গুলো দেখানো হবে:

        কয়েন কাউন্টার (Coin Counter): প্লেয়ার চলতি রান-এ মোট কতটি কয়েন সংগ্রহ করল তা দেখাবে।
        দূরত্ব ও লাইভ স্কোর (Distance/Score Counter): প্লেয়ার কত মিটার দৌড়ালো এবং তার বর্তমান স্কোর কত, তা লাইভ আপডেট হতে থাকবে।
---

## প্রোটোটাইপিং ব্লুপ্রিন্ট (Unity 2017): প্রোটোটাইপিংয়ের মূল উদ্দেশ্য হলো কোনো ফাইনাল গ্রাফিক্স বা আর্ট ছাড়াই গেমের কোর মেকানিক্স (দৌড়ানো, লাফানো, বাধা) কোড দিয়ে কাজ করছে কিনা তা পরীক্ষা করা।

### ১. গেমের মূল মেকানিক্স (Core Mechanics to Test)

* **অবিরাম দৌড়ানো (Endless Running):** ক্যারেক্টার নিজে থেকেই সবসময় সামনের দিকে চলতে থাকবে।
* **লেন পরিবর্তন (Lane Changing):** সোয়াইপ বা কিবোর্ড ইনপুট অনুযায়ী প্লেয়ার ডানে-বামে সরবে।
* **লাফ ও স্লাইড (Jump & Slide):** ইনপুট অনুযায়ী ক্যারেক্টারের লাফানো ও নিচু হওয়া।
* **বাধা ও সংঘর্ষ (Obstacle & Collision):** বাধার সাথে ধাক্কা লাগলে গেম ওভার হওয়া।
* **প্রসিডিউরাল রাস্তা (Procedural Tile Generation):** ক্যারেক্টার সামনে যাওয়ার সাথে সাথে নতুন রাস্তা বা টাইল তৈরি হওয়া এবং পেছনের টাইল ডিলিট হওয়া।

### ২. Unity 2017 প্রজেক্ট সেটআপ ও কাজের ধাপ (Step-by-Step Execution)

#### ধাপ ১: প্রজেক্ট ক্রিয়েশন

* Unity 2017 ওপেন করে একটি নতুন **3D Project** তৈরি করুন।
* নাম দিন: `EndlessRunner_Prototype`।

#### ধাপ ২: প্লেয়ার ও এনভায়রনমেন্ট সেটআপ (3D Primitive Objects)

* **রাস্তা (Road):** `Hierarchy`-তে রাইট ক্লিক করে একটি `Cube` নিন। এর Scale করুন `(X: 5, Y: 1, Z: 30)`। এটি হবে আপনার প্রাথমিক রাস্তার টাইল (Tile)।
* **প্লেয়ার (Player):** আরেকটি `Capsule` বা `Cube` নিন, সেটিকে রাস্তার উপরে রাখুন এবং নাম দিন `Player`। প্লেয়ারের সাথে একটি `Rigidbody` কম্পোনেন্ট যুক্ত করুন।

#### ধাপ ৩: ক্যারেক্টার মুভমেন্ট স্ক্রিপ্ট (PlayerController.cs)

প্লেয়ার অবজেক্টের সাথে একটি C# স্ক্রিপ্ট যুক্ত করুন। প্রোটোটাইপের জন্য কিবোর্ডের (A/D বা Left/Right Arrow) ইনপুট ব্যবহার করে লেন চেঞ্জ এবং (Space) দিয়ে জাম্প করার বেসিক লজিক লিখুন:
File: PlayerController.cs

```csharp
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public SwipeManager swipeManager;
    private Animator anim;

    [Header("Movement Settings")]
    public float forwardSpeed = 10f;
    public float laneDistance = 2f;
    public float laneSwitchSpeed = 10f;
    private int desiredLane = 1;

    [Header("Jump Settings")]
    public float jumpForce = 12f;
    public float gravity = 30f;
    private float verticalVelocity = 0f;
    private bool isGrounded;
    private float groundYPosition = 0f;

    [Header("Slide Settings")]
    public float slideDuration = 1f;
    private bool isSliding = false;
    private CapsuleCollider myCollider;
    private float originalHeight;
    private Vector3 originalCenter;
    private Coroutine slideCoroutine;

    [Tooltip("The exact name of the Slide state in your Animator Controller")]
    public string slideAnimationStateName = "Slide"; 

    private Rigidbody rb;
    private bool isDead = false;

    public int CurrentLane
    {
        get { return desiredLane; }
    }

    public bool IsGroundedProperty
    {
        get { return isGrounded; }
    }

    public bool IsSlidingProperty
    {
        get { return isSliding; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();
        anim = GetComponentInChildren<Animator>();
        
        if (swipeManager == null)
        {
            swipeManager = FindObjectOfType<SwipeManager>();
        }

        if (myCollider != null)
        {
            originalHeight = myCollider.height;
            originalCenter = myCollider.center;
        }

        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = false;
            rb.freezeRotation = true;
        }

        groundYPosition = transform.position.y;
    }

    void Update()
    {
        if (forwardSpeed <= 0)
        {
            if (!isDead)
            {
                isDead = true;
                if (anim != null) anim.SetBool("isDead", true);
            }
            return;
        }

        bool swipeRight = swipeManager != null && swipeManager.SwipeRight;
        bool swipeLeft = swipeManager != null && swipeManager.SwipeLeft;
        bool swipeUp = swipeManager != null && swipeManager.SwipeUp;
        bool swipeDown = swipeManager != null && swipeManager.SwipeDown;

        // ---- 1. Lane Switch Logic ----
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3) desiredLane = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1) desiredLane = 0;
        }

        // ---- 2. Responsive Jump & Slide Controls ----
        bool jumpInput = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || swipeUp;
        bool slideInput = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || swipeDown;

        if (isGrounded)
        {
            verticalVelocity = 0f;

            if (jumpInput)
            {
                if (isSliding) 
                {
                    StopSlide();
                }

                verticalVelocity = jumpForce;
                isGrounded = false;
                if (anim != null) anim.SetBool("isGrounded", false);
            }
            else if (slideInput)
            {
                // DOUBLE SLIDE FIX: If already sliding, stop the running timer coroutine ONLY.
                // Do not reset parameters or collider values just to instantly rewrite them.
                if (isSliding && slideCoroutine != null)
                {
                    StopCoroutine(slideCoroutine);
                    slideCoroutine = null;
                }
                
                slideCoroutine = StartCoroutine(SlideRoutine());
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // ---- 3. Position Calculations & Execution ----
        float targetX = 0f;
        if (desiredLane == 0) targetX = -laneDistance;
        else if (desiredLane == 2) targetX = laneDistance;

        float newX = Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * laneSwitchSpeed);
        float newY = transform.position.y + (verticalVelocity * Time.deltaTime);

        if (!isGrounded && newY <= groundYPosition && verticalVelocity < 0)
        {
            newY = groundYPosition;
            isGrounded = true;
            if (anim != null) anim.SetBool("isGrounded", true);
        }

        if (isGrounded)
        {
            newY = groundYPosition;
        }

        float newZ = transform.position.z + (forwardSpeed * Time.deltaTime);

        transform.position = new Vector3(newX, newY, newZ);
    }

    private IEnumerator SlideRoutine()
    {
        isSliding = true;
        if (anim != null) 
        {
            anim.SetBool("isSliding", true);
            // Re-trigger the animation instantly from frame zero
            anim.Play(slideAnimationStateName, 0, 0f);
        }

        if (myCollider != null)
        {
            myCollider.height = originalHeight / 2f;
            myCollider.center = new Vector3(originalCenter.x, originalCenter.y / 2f, originalCenter.z);
        }

        yield return new WaitForSeconds(slideDuration);

        ResetCollider();
    }

    private void StopSlide()
    {
        if (slideCoroutine != null)
        {
            StopCoroutine(slideCoroutine);
            slideCoroutine = null;
        }
        ResetCollider();
    }

    private void ResetCollider()
    {
        if (myCollider != null)
        {
            myCollider.height = originalHeight;
            myCollider.center = originalCenter;
        }
        if (anim != null) anim.SetBool("isSliding", false);
        isSliding = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            if (anim != null) anim.SetBool("isGrounded", true);
        }

        if (collision.gameObject.CompareTag("LowerObstacle") || collision.gameObject.CompareTag("HigherObstacle"))
        {
            HandleDeath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LowerObstacle") || other.gameObject.CompareTag("HigherObstacle"))
        {
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        forwardSpeed = 0f;
        if (rb != null) rb.velocity = Vector3.zero;
        if (!isDead)
        {
            isDead = true;
            if (anim != null) anim.SetBool("isDead", true);
        }
    }
}
```

#### ধাপ ৫: প্রসিডিউরাল টাইল জেনারেশন (TileManager.cs)

একটি Empty GameObject তৈরি করে এই স্ক্রিপ্টটি দিন, যা প্লেয়ার সামনে যাওয়ার সাথে সাথে নতুন রাস্তার কিউব (Tile) জেনারেট করবে:
File: TileManager.cs

```csharp
using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    [Header("Prefabs & References")]
    public GameObject tilePrefab;              
    public GameObject[] obstaclePrefabs;       
    public Transform playerTransform;
    [Tooltip("স্পেল এফেক্টের পার্টিকেল প্রিফ্যাব এখানে দিন")]
    public GameObject spellEffectPrefab;          
    
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

        tileCounter++; // নতুন টাইল তৈরি হলেই কাউন্টার ১ বাড়বে

        // ---- ঘাস জেনারেট করার অপ্টিমাইজড লজিক ----
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

            // টাইলের চাইল্ড করা হলো যেন ডিলিট হয়ে যায়
            spawnedGrass.transform.SetParent(go.transform);
        }

        // ---- বাধা ও স্পেল এফেক্ট তৈরি করার লজিক ----
        if (spawnObstacle && obstaclePrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            int randomPlacement = Random.Range(0, 3);
            int[] placement = {-2, 2, 0}; 
            GameObject obstacleToSpawn = obstaclePrefabs[randomIndex];

            Vector3 spawnPosition = new Vector3(
                placement[randomPlacement], 
                obstacleToSpawn.transform.position.y, 
                spawnZ + (tileLength / 2f)
            );

            GameObject spawnedObstacle = Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);
            spawnedObstacle.transform.SetParent(go.transform);

            // ---- স্পেল এফেক্ট স্পন করার কাস্টম পার্ট ----
            if (spellEffectPrefab != null)
            {
                Vector3 effectPosition = spawnPosition;

                // অবস্ট্যাকলের ট্যাগ চেক করে এফেক্টের পজিশন ওয়াই-অক্ষ (Y-axis) বরাবর সেট করা হচ্ছে
                if (obstacleToSpawn.CompareTag("LowerObstacle"))
                {
                    // লোয়ার অবস্ট্যাকল (যেমন: পাথর) হলে এফেক্টটি তার ঠিক ওপরে ভাসবে
                    effectPosition.y = spawnPosition.y + 2.3f; 
                }
                else if (obstacleToSpawn.CompareTag("HigherObstacle"))
                {
                    // হায়ার অবস্ট্যাকল (যেমন: পিলার) হলে এফেক্টটি নিচে মাটিতে থাকবে
                    effectPosition.y = 1.0f; // মাটির লেভেল পজিশন
                }

                // এফেক্টটি ইনস্ট্যান্সিয়েট করা এবং বাধার চাইল্ড করে দেওয়া
                GameObject spawnedEffect = Instantiate(spellEffectPrefab, effectPosition, Quaternion.identity);
                spawnedEffect.transform.SetParent(spawnedObstacle.transform);
            }
        }

        spawnZ += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}

```
### ৩. প্রোটোটাইপ টেস্টিং চেকলিস্ট (Testing Checklist)

1. **প্লেয়ার কি অবিরাম সামনে যাচ্ছে?** (Yes)
2. **A/D বা Left/Right Arrow চাপলে কি প্লেয়ার ৩টি লেনের মধ্যে ঠিকঠাক যাতায়াত করছে?** (Yes)
3. **Space চাপলে কি জাম্প হচ্ছে এবং ল্যান্ড করার পর আবার জাম্প করা যাচ্ছে?** (Yes)
4. **রাস্তার টাইলসগুলো কি সামনে স্বয়ংক্রিয়ভাবে তৈরি হচ্ছে এবং পেছনে ডিলিট হচ্ছে?** (Yes)
5. **রাস্তায় কোনো লাল কিউব (Obstacle) রাখলে সেটার সাথে ধাক্কা লাগলে কি গেম থামছে?** (Yes)
---

আপনার প্রজেক্টের সম্পূর্ণ ব্লুপ্রিন্ট এখন প্রস্তুত! প্রটোটাইপ ঠিক ঠাক কাজ করছে।

ডেবলপমেন্ট চলতেছেঃ Professional Development

[ Phase 2: Professional Development ]
 ├── ১. মোবাইল টাচ ইনপুট ও সোয়াইপ লজিক (Touch Input & Swipe)
 ├── ২. আর্ট, অ্যানিমেশন ও রিয়ালিস্টিক ভিজ্যুয়াল (Art & Polish)
 └── ৩. কয়েন, স্কোরিং ও UI আর্কিটেকচার (Data & UI System)

 ২.১ টাচ ও সোয়াইপ ইনপুট সিস্টেম (Mobile Touch Input): যেহেতু এটি একটি মোবাইল গেম (Temple Run-এর মতো), তাই কিবোর্ডের বদলে আমাদের Swipe Detection UI কোড লিখতে হবে। আমাদের এমন একটি স্ক্রিপ্ট লাগবে যা স্ক্রিনে আঙুলের টাচ ট্র্যাক করে Swipe Left/Right/Up/Down নিখুঁতভাবে ডিটেক্ট করতে পারে। 
 করা হয়েছেঃ একটি Empty Object তৈরি করে, তাতে স্কৃপ্ট এড করা হয়েছে। এবং সেটিকে প্লেয়ারের রেফারেন্স এ যুক্ত করা হয়েছে। 
 File: SwipeManager.cs
 ```csharp
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }

    private void Update()
    {
        // প্রতি ফ্রেমের শুরুতে সব ইনপুট ফলস করা হয়
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        #region Standalone Inputs (Mouse)
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
            Debug.Log("[SWIPE MANAGER] Mouse Down Registered at: " + startTouch);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("[SWIPE MANAGER] Mouse Up Registered. Total Drag Delta before reset: " + swipeDelta);
            isDraging = false;
            ResetSwipe();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                ResetSwipe();
            }
        }
        #endregion

        // ডেল্টা দূরত্ব হিসাব করা
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touchCount > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        // সোয়াইপ ডেডজোন চেক (৭০ পিক্সেল)
        if (swipeDelta.magnitude > 70)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            Debug.Log("[SWIPE MANAGER] Deadzone Crossed! Delta Magnitude: " + swipeDelta.magnitude + " (X: " + x + ", Y: " + y + ")");

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    swipeLeft = true;
                    Debug.Log("[SWIPE MANAGER] Swipe LEFT set to TRUE");
                }
                else
                {
                    swipeRight = true;
                    Debug.Log("[SWIPE MANAGER] Swipe RIGHT set to TRUE");
                }
            }
            else
            {
                if (y < 0)
                {
                    swipeDown = true;
                    Debug.Log("[SWIPE MANAGER] Swipe DOWN set to TRUE");
                }
                else
                {
                    swipeUp = true;
                    Debug.Log("[SWIPE MANAGER] Swipe UP set to TRUE");
                }
            }

            // এখানে সরাসরি ResetSwipe() করার কারণে ডাটা হারিয়ে যাচ্ছিল।
            // ড্র্যাগিং বন্ধ করা হলো, তবে ডাটা এই ফ্রেমের জন্য রাখা হলো।
            isDraging = false; 
        }
    }

    private void ResetSwipe()
    {
        startTouch = swipeDelta = Vector2.zero;
    }
}

 ```

২.২:  আর্ট, অ্যানিমেশন ও রিয়ালিস্টিক ভিজ্যুয়াল (Art & Polish):
    a. রাস্টার জন্য টেক্সচারঃ Done;
    b. রাস্তার পুই পার্শে দেয়ালঃ রাস্তার চাইল্ড হিসেবে এবং তাদের জন্য টেক্সারঃ Done
    c. অবস্টাকল এর জন্য টেক্সারঃ Done
    
    d. প্লেয়ার ক্যাপসুল কে আসল প্লেয়ারে রুপান্তরঃ Done.
    f. Lower Obstacle এর উপরে এবং Higher Obstacle এর নিচে একটা দারুন এনিমেশন রাখা। যাতে মনে হয় মূল্যবান কিছু রাখা আছে সেখানেঃ done. 
    g. ৫০০ মিটার করে দৌড়ানোর পর প্লেয়ারের স্পিড বাড়তে থাকবেঃ done.
    h. প্রথম ১০০০ মিটার দৌড়ানোর পরের সব সময়ের জন্য সবুজ আকাশে রাতের গ্যালাক্সি ভেসে উঠবে। এবং ১০-১৫ সেকেন্ড পর পর আকাশে দুটি ডাইনোসর উড়ে যাবে। রাস্তা এবং তার দুই পাশের দেয়াল যেমন আছে , তেমনি থাকবেঃ done.

২.৩: কয়েন, স্কোরিং ও UI আর্কিটেকচার (Data & UI System):
    a. Distance of running: Done.
    b. Scoring: Done.
    c. UI Architecture: need to be done.


Other c# file i used in this project:

File: ObstacleScoring.cs
```csharp
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
```


File: ScoreManager.cs 
```csharp
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    public Transform playerTransform;
    public Text distanceText;
    public Text scoreText;
    
    [Header("Game Over UI")]
    public GameObject gameOverPanel; 
    public Text finalDistanceText;   
    public Text finalScoreText;      

    [Header("Animation Settings")]
    [Tooltip("How long the death animation takes to complete before showing the panel")]
    public float deathAnimationDelay = 2.0f; 

    [Header("Scene Navigation")]
    public string mainMenuSceneName = "StartScene"; 

    private float startZPosition;
    private int score = 0;
    private bool isGameOver = false;

    void Start()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false); 
        
        if (playerTransform != null)
        {
            startZPosition = playerTransform.position.z;
        }
        UpdateScoreUI();
    }

    void Update()
    {
        if (isGameOver) return;
        if (playerTransform == null || distanceText == null) return;

        PlayerController player = playerTransform.GetComponent<PlayerController>();
        if (player != null && player.forwardSpeed <= 0f)
        {
            // Start the coroutine instead of calling the method directly
            StartCoroutine(TriggerGameOverRoutine());
            return;
        }

        float currentDistance = playerTransform.position.z - startZPosition;
        if (currentDistance < 0) currentDistance = 0;

        distanceText.text = "Distance: " + Mathf.FloorToInt(currentDistance).ToString() + "m";
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // Changed into a Coroutine to create a delay
    private System.Collections.IEnumerator TriggerGameOverRoutine()
    {
        isGameOver = true; // Instantly flag true so Update() stops running logic
        
        // Wait here while the character plays the death animation
        yield return new WaitForSeconds(deathAnimationDelay);

        // Calculate and show final values after the wait window
        float finalDistance = playerTransform.position.z - startZPosition;
        if (finalDistance < 0) finalDistance = 0;

        if (finalDistanceText != null) 
            finalDistanceText.text = "Total Distance: " + Mathf.FloorToInt(finalDistance).ToString() + "m";
        
        if (finalScoreText != null) 
            finalScoreText.text = "Obstacles Cleared: " + score.ToString();

        if (gameOverPanel != null) 
            gameOverPanel.SetActive(true); 

        Time.timeScale = 0f; // Freeze game actions only AFTER the panel appears
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(mainMenuSceneName);
    }
}

```


EffectsManager.cs

```csharp
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
            Debug.Log("[SPEED INCREASE] New Speed: " + player.forwardSpeed + " at Distance: " + currentDistance);
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
            Debug.Log("[ENVIRONMENT] Sky Changed to Galaxy Night!");
        }
        else
        {
            Debug.LogWarning("[ENVIRONMENT] Galaxy Skybox Material missing in Inspector!");
        }
    }

    void SpawnTwoDinosaurs()
    {
        Debug.Log("[DINOSAUR] Spawning two dinosaurs in the sky!");
        
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

```


SpllEffect.cs

```csharp
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
```


I added another scene: StartScene

MainMenuController.cs
```csharp
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenuController : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject namePanel;
    public GameObject mainMenuPanel;

    [Header("Inputs & Texts")]
    public InputField nameInputField;
    public Text welcomeText;

    [Header("Scene Settings")]
    public string gameplaySceneName = "Gameplay";

    // Path for log file (same folder as .exe)
    private string logFilePath;

    void Awake()
    {
        // Application.dataPath points to "<exeFolder>/YourGame_Data"
        // So we go one directory up to reach the .exe folder
        string exeFolder = Directory.GetParent(Application.dataPath).FullName;
        logFilePath = Path.Combine(exeFolder, "GameLog.txt");

        Log("Game started. Log file created at: " + logFilePath);
    }

    void Start()
    {
        try
        {
            // Force default pointer
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            Log("Cursor set to default pointer.");

            Log("Start() called.");

            // Log panel states
            Log("NamePanel activeSelf: " + (namePanel != null && namePanel.activeSelf));
            Log("MainMenuPanel activeSelf: " + (mainMenuPanel != null && mainMenuPanel.activeSelf));

            // Log input field and text references
            Log("NameInputField assigned: " + (nameInputField != null));
            Log("WelcomeText assigned: " + (welcomeText != null));

            if (!PlayerPrefs.HasKey("PlayerName"))
            {
                Log("No PlayerName found. Showing name panel.");
                namePanel.SetActive(true);
                mainMenuPanel.SetActive(false);
                Log("NamePanel setActive(true), MainMenuPanel setActive(false).");
            }
            else
            {
                Log("PlayerName found: " + PlayerPrefs.GetString("PlayerName"));
                ShowMainMenu();
            }
        }
        catch (System.Exception ex)
        {
            Log("Error in Start(): " + ex.Message);
        }
    }

    public void SaveNameAndContinue()
    {
        try
        {
            Log("SaveNameAndContinue() called.");
            string playerName = nameInputField.text.Trim();

            if (!string.IsNullOrEmpty(playerName))
            {
                PlayerPrefs.SetString("PlayerName", playerName);
                PlayerPrefs.Save();
                Log("PlayerName saved: " + playerName);
                ShowMainMenu();
            }
            else
            {
                Log("Name input was empty.");
            }
        }
        catch (System.Exception ex)
        {
            Log("Error in SaveNameAndContinue(): " + ex.Message);
        }
    }

    void ShowMainMenu()
    {
        try
        {
            Log("ShowMainMenu() called.");
            namePanel.SetActive(false);
            mainMenuPanel.SetActive(true);

            if (welcomeText != null)
            {
                string playerName = PlayerPrefs.GetString("PlayerName");
                welcomeText.text = "Welcome, " + playerName + "!";
                Log("Welcome text updated for: " + playerName);
            }
        }
        catch (System.Exception ex)
        {
            Log("Error in ShowMainMenu(): " + ex.Message);
        }
    }

    public void PlayGame()
    {
        try
        {
            Log("PlayGame() called. Loading scene: " + gameplaySceneName);
            Time.timeScale = 1f;
            SceneManager.LoadScene(gameplaySceneName);
        }
        catch (System.Exception ex)
        {
            Log("Error in PlayGame(): " + ex.Message);
        }
    }

    // Custom logger method
    private void Log(string message)
    {
        string logEntry = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - " + message;
        Debug.Log(logEntry); // still visible in Unity console
        File.AppendAllText(logFilePath, logEntry + "\n");
    }

    public void QuitGame()
    {
        Log("QuitGame() called. Closing application.");
        Application.Quit();

        // For testing in Editor only
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

```