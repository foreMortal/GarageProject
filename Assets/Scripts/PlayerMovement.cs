using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 gravity = new Vector3(0f, -3f, 0f);
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 dir = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) dir += transform.forward;
        if (Input.GetKey(KeyCode.S)) dir += -transform.forward;
        if (Input.GetKey(KeyCode.A)) dir += -transform.right;
        if (Input.GetKey(KeyCode.D)) dir += transform.right;

        if (dir != Vector3.zero)
            controller.Move(speed * Time.deltaTime * dir + gravity);
    }
}
