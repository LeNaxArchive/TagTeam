using UnityEngine;

public class WindPower : MonoBehaviour
{
    public float zDirection = -100;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.attachedRigidbody)
        {
            other.attachedRigidbody.AddForce(Vector3.forward * zDirection);
        }
    }
}
