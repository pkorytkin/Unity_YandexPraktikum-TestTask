using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform StartPoint;
    public Transform PlayerTransform;
    static PlayerController instance;
    public static PlayerController Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    public Vector3 LastFramePosition
    {
        get { return lastFramePosition; }
        private set { lastFramePosition = value; }
    }
    private Vector3 lastFramePosition;
    public int CurrentFoodCount
    {
        get { return currentFoodCount; }
        private set { currentFoodCount = value;
        }
    }
    private int currentFoodCount = 0;

    public Rigidbody2D PlayerRigidbody;

    public Vector2 UpForce;
    private void Awake()
    {
        Instance = this;
    }
    private void FixedUpdate()
    {
        
        if (MenuController.Instance.IsGameInProgress)
        {
            lastFramePosition = PlayerTransform.position;
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
            {
                //
                //PlayerRigidbody.velocity = Vector2.zero;
                PlayerRigidbody.AddForce(UpForce);
            }
        }
    }
    void ResetPosition()
    {
        currentFoodCount = 0;
        PlayerTransform.SetPositionAndRotation(StartPoint.position, StartPoint.rotation);
    }
    private void OnDisable()
    {
        ResetPosition();
    }
    private void OnEnable()
    {
        ResetPosition();
    }
    public void ConsumeFood(int Count = 1)
    {
        currentFoodCount += Count;
    }
    public void StopGame()
    {
        currentFoodCount = 0;
        MenuController.Instance.StopGame();
    }
}
