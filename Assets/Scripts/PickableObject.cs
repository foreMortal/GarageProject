using UnityEngine;

public class PickableObject : InteractableObject
{
    private const string hoverString = "E: Взять ";
    private const string interactedString = "E: Выбросить ";

    [SerializeField] private string objectName;

    private Rigidbody rb;

    public string ObjectName { get { return objectName; } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override string Hover(Interact _)
    {
        return hoverString + objectName;
    }

    public override void Interact(Interact player, ref string hint)
    {
        hint = interactedString + objectName;
        rb.useGravity = false;
        player.PickUp(this);
    }

    public void Drop()
    {
        rb.useGravity = true;
    }
}
