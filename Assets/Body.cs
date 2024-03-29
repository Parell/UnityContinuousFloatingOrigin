using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Body : MonoBehaviour
{
    public BodyData bodyData = new BodyData();
    public new Rigidbody rigidbody;
    public bool isColliding;

    private void OnCollisionEnter(Collision collision)
    {
        Thang(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        Thang(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        Thang(collision);
    }

    private void Thang(Collision collision)
    {
        if (this == PhysicsManager.centralBody)
        {
            var acceleration = -collision.impulse / (bodyData.mass * Time.fixedDeltaTime);
            foreach (var body in PhysicsManager.bodies)
            {
                body.bodyData.acceleration += acceleration;
            }

            // do normal floting origin here to stop slight drift of position caused by collision impulse in unity not being perfect
            // so jsut do normal origin and velocity rest here 
        }
    }

    public void AddForce(Vector3 force)
    {
        if (this == PhysicsManager.centralBody)
        {
            foreach (var body in PhysicsManager.bodies)
            {
                if (body == PhysicsManager.centralBody) { continue; }

                body.bodyData.acceleration -= force / bodyData.mass;
            }
        }
        else
        {
            bodyData.acceleration += force / bodyData.mass;
        }
    }
}

[System.Serializable]
public class BodyData
{
    public float mass;
    public Vector3 position;
    public Vector3 velocity;
    public Vector3 acceleration;
}