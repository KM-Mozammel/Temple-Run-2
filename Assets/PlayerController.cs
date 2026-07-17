using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 10f;
    public float laneDistance = 2.5f; // দুই লেনের মধ্যবর্তী দূরত্ব (Left: -2.5, Middle: 0, Right: 2.5)
    public float laneSwitchSpeed = 10f; // লেন পরিবর্তনের গতি
    private int desiredLane = 1; // 0: Left, 1: Middle, 2: Right

    [Header("Jump Settings")]
    public float jumpForce = 12f;
    public float gravity = 30f; // ক্যারেক্টারকে লাফানোর পর মাটিতে নামানোর জন্য নিজস্ব গ্র্যাভিটি
    private float verticalVelocity = 0f; // ক্যারেক্টারের Y অক্ষের গতিবেগ
    private bool isGrounded;

    [Header("Slide Settings")]
    public float slideDuration = 1f; // কতক্ষণ স্লাইড চলবে
    private bool isSliding = false;
    private CapsuleCollider myCollider;
    private float originalHeight;
    private Vector3 originalCenter;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();

        // স্লাইড করার পর আবার আগের সাইজে ফেরার জন্য অরিজিনাল সাইজ সেভ করে রাখা
        if (myCollider != null)
        {
            originalHeight = myCollider.height;
            originalCenter = myCollider.center;
        }

        // ফিজিক্সের অতিরিক্ত ঝামেলা এড়াতে রিজিডবডিকে কাস্টমাইজ করা
        if (rb != null)
        {
            rb.useGravity = false; // আমরা কোড দিয়ে নিজস্ব গ্র্যাভিটি চালাবো যাতে জাম্প লক না হয়
            rb.isKinematic = false;
            rb.freezeRotation = true;
        }
    }

    void Update()
    {
        // গেম ওভার হলে বা স্পিড ০ হলে কোনো মুভমেন্ট বা ইনপুট কাজ করবে না
        if (forwardSpeed <= 0) return;

        // ---- ১. লেন পরিবর্তনের ইনপুট (A/D বা Arrow Keys) ----
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Right Arrow Clicked!");
            desiredLane++;
            if (desiredLane == 3) desiredLane = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Left Arrow Clicked!");
            desiredLane--;
            if (desiredLane == -1) desiredLane = 0;
        }

        // ---- ২. জাম্প ও গ্র্যাভিটি লজিক (১০০% ফিক্সড) ----
        if (isGrounded)
        {
            verticalVelocity = -0.1f; // মাটিতে থাকলে সামান্য ডাউন-ফোর্স রাখা যাতে অন-গ্রাউন্ড ডিটেক্ট হয়

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && !isSliding)
            {
                Debug.Log("Jumping - Custom Physics Applied");
                verticalVelocity = jumpForce; // প্লেয়ারকে ওপরে তোলার বেগ দেওয়া
                isGrounded = false;
            }
        }
        else
        {
            // প্লেয়ার বাতাসে থাকলে প্রতি ফ্রেমে গ্র্যাভিটি অনুযায়ী তাকে নিচের দিকে টানা হবে
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // ---- ৩. স্লাইড ইনপুট ----
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && isGrounded && !isSliding)
        {
            Debug.Log("Sliding Arrow Clicked!");
            StartCoroutine(SlideRoutine());
        }

        // ---- ৪. পজিশন হিসাব ও অবিরাম দৌড়ানো ( ফাইনাল মুভমেন্ট লুপ ) ----
        float targetX = 0f;
        if (desiredLane == 0) targetX = -laneDistance;
        else if (desiredLane == 2) targetX = laneDistance;

        // স্মুথ লেন চেঞ্জ এবং ফরওয়ার্ড মুভমেন্ট হিসাব
        float newX = Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * laneSwitchSpeed);
        float newY = transform.position.y + (verticalVelocity * Time.deltaTime); // জাম্পের Y পজিশন যোগ করা
        float newZ = transform.position.z + (forwardSpeed * Time.deltaTime);

        // মাটিতে পড়ে যাওয়ার ব্যাকআপ চেক (ভুল করে নিচে নেমে গেলে ট্র্যাকে আটকে রাখা)
        if (newY < 1.0f && isGrounded) 
        {
            newY = transform.position.y; 
        }

        // ফাইনাল পজিশন অ্যাসাইন (এখানে মুভমেন্ট, জাম্প ও লেন চেঞ্জ সব একসাথে এক্সিকিউট হবে)
        transform.position = new Vector3(newX, newY, newZ);
    }

    // স্লাইড করার জন্য Coroutine
    private System.Collections.IEnumerator SlideRoutine()
    {
        isSliding = true;

        // ১. কোলাইডার ছোট করা
        if (myCollider != null)
        {
            myCollider.height = originalHeight / 2f;
            myCollider.center = new Vector3(originalCenter.x, originalCenter.y / 2f, originalCenter.z);
        }

        // ২. ভিজ্যুয়াল ক্যাপসুল চ্যাপ্টা করা
        transform.localScale = new Vector3(1f, 0.5f, 1f);

        yield return new WaitForSeconds(slideDuration);

        // ৩. কোলাইডার স্বাভাবিক করা
        if (myCollider != null)
        {
            myCollider.height = originalHeight;
            myCollider.center = originalCenter;
        }

        // ৪. ভিজ্যুয়াল সাইজ স্বাভাবিক করা
        transform.localScale = new Vector3(1f, 1f, 1f);

        isSliding = false;
    }

    // ---- ৫. কোলাইড ও সংঘর্ষ ডিটেকশন (Collision Detection) ----
    private void OnCollisionEnter(Collision collision)
    {
        // মাটির সাথে টাচ থাকলে জাম্প ও স্লাইড আবার সক্রিয় হবে
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // বাধার (Obstacle) সাথে ধাক্কা লাগলে গেম ওভার
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over! মন্দিরের দানব আপনাকে ধরে ফেলেছে।");
            forwardSpeed = 0f; 
            if (rb != null) rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over! (Trigger) মন্দিরের দানব আপনাকে ধরে ফেলেছে।");
            forwardSpeed = 0f;
            if (rb != null) rb.velocity = Vector3.zero;
        }
    }
}