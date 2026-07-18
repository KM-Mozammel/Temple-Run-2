### সাধারণ পরিচিতি (General Information):
    গেমের নাম: অবিরাম দৌড়।
    গেমের ধরণ (Genre): এন্ডলেস রানার (Temple Run-এর মতো)।
    আর্ট স্টাইল (Art Style): রিয়ালিস্টিক (Realistic)।

    গেমের গল্প (Game Story): 
        এক প্রাচীন মন্দিরের লুকানো ধন চুরি করার পর, মন্দিরের রক্ষী দানব আপনার পিছু নেয়। এখন আপনার সামনে একটাই রাস্তা, তা হলো অবিরাম দৌড়ে সেই দানবের হাত থেকে নিজের জীবন বাঁচানো।

    গেমের নিয়ম ও স্কোরিং সিস্টেম (Rules & Scoring):
        মূল নিয়ম: প্লেয়ারকে অবিরাম সামনের দিকে দৌড়াতে হবে এবং মন্দিরের রক্ষী দানব থেকে বাঁচতে হবে। সামনে আসা বিভিন্ন বাধা যেমন পাথর বা গাছের শিকড় এড়িয়ে চলতে হবে।

        স্কোরিং সিস্টেম: প্লেয়ারের মোট স্কোর দুটি বিষয়ের ওপর নির্ভর করবে:
            ১. মন্দিরে কতখানি দূরত্ব (Distance) অতিক্রম করা হয়েছে।
            ২. পথ থেকে তিনি কতগুলি কয়েন (Coins) সংগ্রহ করেছেন।
            ** যত বেশি দূরত্ব অতিক্রম করা যাবে এবং যত বেশি কয়েন সংগ্রহ করা হবে, প্লেয়ারের স্কোর তত বাড়বে।

    গেমের কন্ট্রোলস (Game Controls):

        বাঁ-দিকে সোয়াইপ (Swipe Left): প্লেয়ার বাঁ-দিকে যাবে (Lane change)।
        ডানদিকে সোয়াইপ (Swipe Right): প্লেয়ার ডানদিকে যাবে (Lane change)।
        ওপরের দিকে সোয়াইপ (Swipe Up): প্লেয়ার লাফ দেবে (Jump)।
        নিচের দিকে সোয়াইপ (Swipe Down): প্লেয়ার মাটির সাথে স্লাইড করবে (Slide)।

    বাধা বা অবস্ট্যাকল ডিজাইন (Obstacle Design):

        নিচু বাধা (Low Obstacles): যেমন বড় পাথর বা গাছের শিকড়, যেগুলোর ওপর দিয়ে প্লেয়ারকে **লাফ (Jump)** দিয়ে পার হতে হবে।
        উंचे বাধা (High Obstacles): যেমন ভেঙে পড়া প্রাচীন মন্দিরের পিলার বা গাছের নিচু ডাল, যেগুলোর নিচ দিয়ে প্লেয়ারকে **স্লাইড (Slide)** করে পার হতে হবে।
        বাঁক (Turns): হঠাৎ আসা ডানে বা বামে যাওয়ার তীক্ষ্ণ মোড়, যেখানে সঠিক সময়ে সোয়াইপ না করলে প্লেয়ার রাস্তা থেকে নিচে পড়ে যাবে বা দেয়ালে ধাক্কা খাবে।

    ইউজার ইন্টারফেস (UI Design): গেম প্লে স্ক্রিনের ওপরের অংশে রিয়াল-টাইমে নিচের বিষয়গুলো দেখানো হবে:

        কয়েন কাউন্টার (Coin Counter): প্লেয়ার চলতি রান-এ মোট কতটি কয়েন সংগ্রহ করল তা দেখাবে।
        দূরত্ব ও লাইভ স্কোর (Distance/Score Counter): প্লেয়ার কত মিটার দৌড়ালো এবং তার বর্তমান স্কোর কত, তা লাইভ আপডেট হতে থাকবে।
---

## প্রোটোটাইপিং ব্লুপ্রিন্ট (Unity 2017): গেমের ডিজাইন পেপারে যেমন থাকে, প্রোটোটাইপিংয়ের মূল উদ্দেশ্য হলো কোনো ফাইনাল গ্রাফিক্স বা আর্ট ছাড়াই গেমের কোর মেকানিক্স (দৌড়ানো, লাফানো, বাধা) কোড দিয়ে কাজ করছে কিনা তা পরীক্ষা করা।

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

```csharp
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public SwipeManager swipeManager;

    [Header("Movement Settings")]
    public float forwardSpeed = 10f;
    public float laneDistance = 2.5f;
    public float laneSwitchSpeed = 10f;
    private int desiredLane = 1;

    [Header("Jump Settings")]
    public float jumpForce = 12f;
    public float gravity = 30f;
    private float verticalVelocity = 0f;
    private bool isGrounded;

    [Header("Slide Settings")]
    public float slideDuration = 1f;
    private bool isSliding = false;
    private CapsuleCollider myCollider;
    private float originalHeight;
    private Vector3 originalCenter;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();

        if (swipeManager == null)
        {
            swipeManager = FindObjectOfType<SwipeManager>();
            if (swipeManager != null)
                Debug.Log("[PLAYER START] SwipeManager found automatically!");
            else
                Debug.LogError("[PLAYER START] CRITICAL: SwipeManager COULD NOT be found!");
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
    }

    void Update()
    {
        // Update ফাংশনের ভেতর একদম শুরুতে এটি যোগ করতে পারেন:
        if (swipeManager == null)
        {
            swipeManager = FindObjectOfType<SwipeManager>();
        }
        
        if (forwardSpeed <= 0) return;

        // সোয়াইপ ম্যানেজার থেকে ডেটা রিড করা
        bool swipeRight = (swipeManager != null) ? swipeManager.SwipeRight : false;
        bool swipeLeft = (swipeManager != null) ? swipeManager.SwipeLeft : false;
        bool swipeUp = (swipeManager != null) ? swipeManager.SwipeUp : false;
        bool swipeDown = (swipeManager != null) ? swipeManager.SwipeDown : false;

        // ডিবাগ মেসেজ: প্লেয়ার স্ক্রিপ্ট আসলেই সোয়াইপ ডাটা পাচ্ছে কিনা চেক করা
        if (swipeLeft || swipeRight || swipeUp || swipeDown)
        {
            Debug.Log("[PLAYER RECEIVE] Swipe values in PlayerController -> Left: " + swipeLeft + ", Right: " + swipeRight + ", Up: " + swipeUp + ", Down: " + swipeDown);
        }

        // ---- ১. লেন পরিবর্তনের ইনপুট ----
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || swipeRight)
        {
            Debug.Log("[PLAYER ACTION] Moving Right Triggered!");
            desiredLane++;
            if (desiredLane == 3) desiredLane = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || swipeLeft)
        {
            Debug.Log("[PLAYER ACTION] Moving Left Triggered!");
            desiredLane--;
            if (desiredLane == -1) desiredLane = 0;
        }

        // ---- ২. জাম্প ও গ্র্যাভিটি লজিক ----
        if (isGrounded)
        {
            verticalVelocity = -0.1f;

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || swipeUp) && !isSliding)
            {
                Debug.Log("[PLAYER ACTION] Jumping Triggered!");
                verticalVelocity = jumpForce;
                isGrounded = false;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // ---- ৩. স্লাইড ইনপুট ----
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || swipeDown) && isGrounded && !isSliding)
        {
            Debug.Log("[PLAYER ACTION] Sliding Triggered!");
            StartCoroutine(SlideRoutine());
        }

        // ---- ৪. পজিশন হিসাব ও অবিরাম দৌড়ানো ----
        float targetX = 0f;
        if (desiredLane == 0) targetX = -laneDistance;
        else if (desiredLane == 2) targetX = laneDistance;

        float newX = Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * laneSwitchSpeed);
        float newY = transform.position.y + (verticalVelocity * Time.deltaTime);
        float newZ = transform.position.z + (forwardSpeed * Time.deltaTime);

        if (newY < 1.0f && isGrounded)
        {
            newY = transform.position.y;
        }

        transform.position = new Vector3(newX, newY, newZ);
    }

    private System.Collections.IEnumerator SlideRoutine()
    {
        isSliding = true;
        if (myCollider != null)
        {
            myCollider.height = originalHeight / 2f;
            myCollider.center = new Vector3(originalCenter.x, originalCenter.y / 2f, originalCenter.z);
        }
        transform.localScale = new Vector3(1f, 0.5f, 1f);

        yield return new WaitForSeconds(slideDuration);

        if (myCollider != null)
        {
            myCollider.height = originalHeight;
            myCollider.center = originalCenter;
        }
        transform.localScale = new Vector3(1f, 1f, 1f);
        isSliding = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            forwardSpeed = 0f;
            if (rb != null) rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            forwardSpeed = 0f;
            if (rb != null) rb.velocity = Vector3.zero;
        }
    }
}
---
#### ধাপ ৪: ক্যামেরা ফলো স্ক্রিপ্ট (CameraFollow.cs)

ক্যামেরা যেন সবসময় প্লেয়ারের পেছনে একই দূরত্ব বজায় রেখে চলে, তার জন্য `Main Camera`-তে এই স্ক্রিপ্টটি দিন:

```csharp
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, playerTransform.position.z + offset.z);
        transform.position = newPosition;
    }
}

```

#### ধাপ ৫: প্রসিডিউরাল টাইল জেনারেশন (TileManager.cs)

একটি Empty GameObject তৈরি করে এই স্ক্রিপ্টটি দিন, যা প্লেয়ার সামনে যাওয়ার সাথে সাথে নতুন রাস্তার কিউব (Tile) জেনারেট করবে:

```csharp
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
---

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

 SwipeManager.cs
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
 ---
