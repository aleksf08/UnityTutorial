
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 moveInput;

    void Update()
    {
        // Move the player based on input
        Vector2 pos = transform.position;
        pos += moveInput * speed * Time.deltaTime;
        transform.position = pos;
    }

    void OnEnable()
    {
        // Register for input events
        Keyboard.current.onTextInput += OnTextInput;
    }

    void OnDisable()
    {
        Keyboard.current.onTextInput -= OnTextInput;
    }

    void OnTextInput(char c)
    {
        // Not used, but required for event registration
    }

    void FixedUpdate()
    {
        // Read input from the new Input System
        moveInput = Vector2.zero;
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            moveInput.y += 1;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            moveInput.y -= 1;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            moveInput.x -= 1;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            moveInput.x += 1;
        moveInput = moveInput.normalized;
    }
}
