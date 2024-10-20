using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public virtual string Hover(Interact player)
    {
        return "";
    }

    public virtual void Interact(Interact player, ref string hint)
    {
        
    }
}