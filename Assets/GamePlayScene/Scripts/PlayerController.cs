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