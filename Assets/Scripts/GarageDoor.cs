using UnityEngine;

public class GarageDoor : InteractableObject
{
    [SerializeField] private Vector3 secondPos;
    [SerializeField] private Quaternion secondRot;

    private bool active;
    private float t;
    private Vector3 firstPos;
    private Quaternion firstRotate;

    private void Awake()
    {
        firstPos = transform.position;
        firstRotate = transform.rotation;
    }

    public override string Hover(Interact player)
    {
        if (!active)
            return "E: Открыть гаражную дверь";
        else return "";
    }

    public override void Interact(Interact player, ref string _)
    {
        active = true;
    }

    private void Update()
    {
        if (active)
        {
            t += Time.deltaTime * 0.3f;
            Vector3 pos = Vector3.Lerp(firstPos, secondPos, t);
            Quaternion rot = Quaternion.Slerp(firstRotate, secondRot, t);

            transform.SetLocalPositionAndRotation(pos, rot);

            if(t >= 1f)
            {
                active = false;
                gameObject.layer = 0;
            }
        }
    }
}
