using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    public static PhysicsManager Instance;

    [SerializeField] private Body _centralBody;
    [SerializeField] private List<Body> _bodies;
    [TextArea]
    public string discription;

    private void Start()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < _bodies.Count; i++)
        {
            _bodies[i].bodyData.mass = _bodies[i].rigidbody.mass;
            _bodies[i].bodyData.position = _bodies[i].rigidbody.position;
            _bodies[i].bodyData.velocity = _bodies[i].rigidbody.velocity;

            _bodies[i].rigidbody.AddForce(_bodies[i].bodyData.acceleration, ForceMode.Acceleration);
            _bodies[i].bodyData.acceleration = Vector3.zero;
            _bodies[i].isColliding = false;
        }
    }

    public static Body centralBody
    {
        get { return Instance._centralBody; }
        set { Instance._centralBody = value; }
    }

    public static List<Body> bodies
    {
        get { return Instance._bodies; }
        set { Instance._bodies = value; }
    }
}
