using UnityEngine;

public class Mover : MonoBehaviour
{
    private Body body;
    [SerializeField] private Vector3 force;

    private void Start()
    {
        body = GetComponent<Body>();
    }

    private void FixedUpdate()
    {
        body.AddForce(force);
    }
}
