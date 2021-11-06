using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;

    [SerializeField] private Transform playerBody;

    private float _rotation = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _rotation -= mouseY;
        _rotation = Mathf.Clamp(_rotation,-90f,90f);
        transform.localRotation = Quaternion.Euler(_rotation, 0f, 0f);
        playerBody.Rotate(Vector3.up* mouseX);
    }
}
