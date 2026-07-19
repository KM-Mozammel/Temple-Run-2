using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public SwipeManager swipeManager;
    private Animator anim; // ক্যারেক্টার অ্যানিমেশনের জন্য

    [Header("Movement Settings")]
    public float forwardSpeed = 10f;
    public float laneDistance = 2f;
    public float laneSwitchSpeed = 10f;
    private int desiredLane = 1;

    [Header("Jump Settings")]
    public float jumpForce = 12f; // Rigidbody ফোর্সের জন্য মান কিছুটা কমানো লাগতে পারে
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

        // চাইল্ড অবজেক্টে থাকা অ্যানিমেটর খুঁজে নেওয়া
        anim = GetComponentInChildren<Animator>();

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
        if (swipeManager == null)
        {
            swipeManager = FindObjectOfType<SwipeManager>();
        }

        if (forwardSpeed <= 0)
        {
            // গতি ০ হলে প্লেয়ার মারা গেছে বা ধাক্কা খেয়েছে, অ্যানিমেটরকে জানানো
            if (anim != null) anim.SetTrigger("isDead");
            return;
        }

        // সোয়াইপ ম্যানেজার থেকে ডেটা রিড করা
        bool swipeRight = (swipeManager != null) ? swipeManager.SwipeRight : false;
        bool swipeLeft = (swipeManager != null) ? swipeManager.SwipeLeft : false;
        bool swipeUp = (swipeManager != null) ? swipeManager.SwipeUp : false;
        bool swipeDown = (swipeManager != null) ? swipeManager.SwipeDown : false;

        // ---- ১. লেন পরিবর্তনের ইনপুট ----
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

        // ---- ২. জাম্প ও গ্র্যাভিটি লজিক ----
        if (isGrounded)
        {
            verticalVelocity = -0.1f;

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || swipeUp) && !isSliding)
            {
                verticalVelocity = jumpForce;
                isGrounded = false;

                // অ্যানিমেশন আপডেট
                if (anim != null) anim.SetBool("isGrounded", false);
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // ---- ৩. স্লাইড ইনপুট ----
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || swipeDown) && isGrounded && !isSliding)
        {
            StartCoroutine(SlideRoutine());
        }

        // ---- ৪. পজিশন হিসাব ও অবিরাম দৌড়ানো ----
        float targetX = 0f;
        if (desiredLane == 0) targetX = -laneDistance;
        else if (desiredLane == 2) targetX = laneDistance;

        float newX = Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * laneSwitchSpeed);
        float newY = transform.position.y + (verticalVelocity * Time.deltaTime);
        float newZ = transform.position.z + (forwardSpeed * Time.deltaTime);

        // গ্রাউন্ড লেভেল ফিক্সিং (যাতে প্লেয়ার মাটির নিচে না ঢুকে যায়)
        if (newY < 0.2f && isGrounded)
        {
            newY = 0.2f; // আপনার রোড এর উচ্চতা অনুযায়ী এটি সামঞ্জস্য করতে পারেন
        }

        transform.position = new Vector3(newX, newY, newZ);
    }

    private System.Collections.IEnumerator SlideRoutine()
    {
        isSliding = true;
        if (anim != null) anim.SetBool("isSliding", true); // স্লাইড অ্যানিমেশন শুরু

        if (myCollider != null)
        {
            // স্লাইড করার সময় কোল্ডারের সাইজ অর্ধেক করা যাতে উঁচু বাধার নিচ দিয়ে যাওয়া যায়
            myCollider.height = originalHeight / 2f;
            myCollider.center = new Vector3(originalCenter.x, originalCenter.y / 2f, originalCenter.z);
        }

        yield return new WaitForSeconds(slideDuration);

        if (myCollider != null)
        {
            // কোল্ডারের সাইজ আগের মতো করা
            myCollider.height = originalHeight;
            myCollider.center = originalCenter;
        }

        if (anim != null) anim.SetBool("isSliding", false); // স্লাইড অ্যানিমেশন শেষ
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
            forwardSpeed = 0f;
            if (rb != null) rb.velocity = Vector3.zero;
            if (anim != null) anim.SetTrigger("isDead"); // প্লেয়ার ডেড অ্যানিমেশন ট্রিগার
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LowerObstacle") || other.gameObject.CompareTag("HigherObstacle"))
        {
            forwardSpeed = 0f;
            if (rb != null) rb.velocity = Vector3.zero;
            if (anim != null) anim.SetTrigger("isDead");
        }
    }
}