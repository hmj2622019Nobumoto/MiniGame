using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    private float xRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = 0f;
        float mouseY = 0f;

        if (UnityEngine.InputSystem.Mouse.current != null)
        {
            var delta = UnityEngine.InputSystem.Mouse.current.delta.value;
            mouseX = delta.x * (mouseSensitivity * 0.1f);
            mouseY = delta.y * (mouseSensitivity * 0.1f);
        }
      
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
       transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        if (playerBody != null)
        {
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
