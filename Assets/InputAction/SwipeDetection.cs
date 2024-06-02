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
    [SerializeField] private PlayerJump playerJump;
   
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
            Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
            Vector3 direction = endPosition - startPosition;

            playerJump.Jump(SwipeDirection(direction));
        }

        else playerJump.Jump(Vector3.forward);
    }

    private Vector3 SwipeDirection(Vector3 direction)
    {
        float dotUp = Vector3.Dot(Vector3.up, direction);
        float dotDown = Vector3.Dot(Vector3.down, direction);
        float dotLeft = Vector3.Dot(Vector3.left, direction);
        float dotRight = Vector3.Dot(Vector3.right, direction);


        if (dotUp > directionThreshold && dotUp > dotRight && dotUp > dotLeft)
        {
            return Vector3.forward;
        }
        else if (dotDown > directionThreshold && dotDown > dotLeft && dotDown > dotRight)
        {
            return Vector3.back;
        }
        else if (dotLeft > directionThreshold)
        {
            return Vector3.left;
        }
        else if (dotRight > directionThreshold)
        {
            return Vector3.right;
        }

        else return Vector3.forward;
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
