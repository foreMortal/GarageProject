using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float sens;
    [SerializeField] private InputAction action;
    private Transform buddy;
    private Vector3 prevPos;

    private float xRot = 180f, yRot;

    private void OnEnable()
    {
        action.Enable();
    }
    private void OnDisable()
    {
        action.Disable();
    }

    private void Awake()
    {
        buddy = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;

        Vector2 delta = action.ReadValue<Vector2>();

        xRot += delta.x * sens;
        yRot += delta.y * sens;

        yRot = Mathf.Clamp(yRot, -90f, 90f);

        buddy.rotation = Quaternion.Euler(0f, xRot, 0f);
        transform.rotation = Quaternion.Euler(-yRot, xRot, 0f);
    }
}
