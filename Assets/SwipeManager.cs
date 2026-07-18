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