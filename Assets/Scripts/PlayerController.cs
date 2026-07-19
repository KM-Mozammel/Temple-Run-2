using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public SwipeManager swipeManager;

    [Header("Movement Settings")]
    public float forwardSpeed = 10f;
    public float laneDistance = 2f;
    public float laneSwitchSpeed = 10f;
    private int desiredLane = 1;

    [Header("Jump Settings")]
    public float jumpForce = 30f;
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