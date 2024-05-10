using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField]
    private float minimumDistance = 2f;
    [SerializeField]
    private float maximumTime = 1f;
    [SerializeField, Range(0, 1)]
    private float directionThreshold = 0.9f;

    private InputManager inputManager;

    private Vector3 startPosition, endPosition;
    private float startTime, endTime;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if(Vector3.Distance(startPosition, endPosition) >= minimumDistance
            && (endTime - startTime) <= maximumTime)
        {
            Debug.Log("Detect");
            Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
            Vector3 direction = endPosition - startPosition;
            SwipeDirection(direction);
        }
    }

    private void SwipeDirection(Vector3 direction)
    {
        float dotUp = Vector3.Dot(Vector3.up, direction);
        float dotDown = Vector3.Dot(Vector3.down, direction);
        float dotLeft = Vector3.Dot(Vector3.left, direction);
        float dotRight = Vector3.Dot(Vector3.right, direction);


        if (dotUp > directionThreshold && dotUp > dotRight && dotUp > dotLeft)
        {
            Debug.Log("Up");
        }
        else if (dotDown > directionThreshold&& dotDown > dotLeft && dotDown > dotRight)
        {
            Debug.Log("Down");
        }
        else if (dotLeft > directionThreshold)
        {
            Debug.Log("Left");
        }
        else if (dotRight > directionThreshold)
        {
            Debug.Log("Right");
        }
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }
}
