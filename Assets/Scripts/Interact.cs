using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    [SerializeField] private Text showText;
    [SerializeField] private float holdRange;
    [SerializeField] private float length;

    private PickableObject pickedObject;
    private bool picked, hovered;
    private string hint = "";

    public bool Picked { get { return picked; } }
    public PickableObject PickedObject { get { return pickedObject; } }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, length, 1 << 6))
        {
            if (!hovered)
            {
                hovered = true;

                showText.text = hit.collider.GetComponent<InteractableObject>().Hover(this);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (picked) pickedObject.Drop();
                    
                    hit.collider.GetComponent<InteractableObject>().Interact(this, ref hint);
                    showText.text = hint;
                }
            }
        }
        else if (hovered)
        {
            showText.text = hint;
            hovered = false;
        }
        else if (picked)
        { 
            if (Input.GetKeyDown(KeyCode.E))
            {
                pickedObject.Drop();
                Drop();
            }
        }
    }

    private void LateUpdate()
    {
        if (picked)
        {
            Vector3 pos = transform.position + (transform.forward + -transform.up * 0.5f) * holdRange;
            pickedObject.transform.SetPositionAndRotation(pos, transform.rotation);
        }
    }

    public void Drop()
    {
        pickedObject = null;
        hint = "";
        showText.text = hint;
        picked = false;
    }

    public void PickUp(PickableObject pick)
    {
        pickedObject = pick;
        picked = true;
    }
}
