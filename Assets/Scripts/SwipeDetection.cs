using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField]
    private float minimumDistance = .2f;
    [SerializeField]
    private float maximumTime = 1f;
    [SerializeField, Range(0f, 1f)]
    private float directionThreshold = .9f;
    private InputManager inputManager;
    public GameObject character;
    private Rigidbody2D rb;
    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;
    public float moveSpeed = 3f;

    private void Awake() {
        inputManager = InputManager.Instance;
        rb = character.GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable() {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time) {
        startPosition = position;
        startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time) {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe () {
        if(Vector3.Distance(startPosition, endPosition) >= minimumDistance &&
            (endTime - startTime) <= maximumTime) {
                Debug.Log("Swipe detected");
                Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
                Vector3 direction = endPosition - startPosition;
                // Vector2 direction2D = (Vector2)direction.normalized;
                SwipeDirection((Vector2)direction);
            }
    }

    private void SwipeDirection(Vector2 direction) {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold) {
            Debug.Log("Swipe up");
            rb.velocity = Vector2.up * moveSpeed;
            // rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * Vector2.up);
        }
        if (Vector2.Dot(Vector2.down, direction) > directionThreshold) {
            Debug.Log("Swipe down");
            rb.velocity = Vector2.down * moveSpeed;
            // rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * Vector2.down);
        }
        if (Vector2.Dot(Vector2.left, direction) > directionThreshold) {
            Debug.Log("Swipe left");
            rb.velocity = Vector2.left * moveSpeed;
            //rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * Vector2.left);
        }
        if (Vector2.Dot(Vector2.right, direction) > directionThreshold) {
            Debug.Log("Swipe right");
            rb.velocity = Vector2.right * moveSpeed;
            //rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * Vector2.right);
        }
    }
}
