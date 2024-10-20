using UnityEngine;

public class PutInPickup : InteractableObject
{
    [SerializeField] private Transform[] positions;

    private int index;

    public override string Hover(Interact player)
    {
        if (player.Picked)
        {
            return "E: Положить в пикап " + player.PickedObject.ObjectName;
        }
        else
        {
            return "";
        }
    }

    public override void Interact(Interact player, ref string _)
    {
        if (player.Picked) 
        {
            player.PickedObject.GetComponent<Rigidbody>().isKinematic = true;
            player.PickedObject.gameObject.layer = 0;
            player.PickedObject.transform.SetLocalPositionAndRotation(positions[index].position, Quaternion.identity);
            player.Drop();
            index++;
        }
    }
}
