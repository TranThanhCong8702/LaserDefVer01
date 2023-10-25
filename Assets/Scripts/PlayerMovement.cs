using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float leftPadding;
    [SerializeField] float rightPadding;
    [SerializeField] float topPadding;
    [SerializeField] float bottomPadding;
    [SerializeField] float MoveSpeed = 1f;
    Vector2 RawInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;
    private void Start()
    {
        shooter = GetComponent<Shooter>();
        Camera mainCam = Camera.main;
        minBounds = mainCam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCam.ViewportToWorldPoint(new Vector2(1, 1));
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMoving();
    }

    private void PlayerMoving()
    {
        Vector2 delta = RawInput * MoveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + leftPadding, maxBounds.x - rightPadding);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + bottomPadding, maxBounds.y - topPadding);
        transform.position = newPos;
    }

    void OnMove(InputValue inputValue)
    {
        RawInput = inputValue.Get<Vector2>();
    }
    void OnFire(InputValue inputValue)
    {
        if (shooter != null)
        {
            shooter.IsFiring = inputValue.isPressed;
            Debug.Log("Hello");
        }

    }
}
