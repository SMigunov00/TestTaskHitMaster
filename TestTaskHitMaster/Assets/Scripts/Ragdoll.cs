using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;

    private void Awake()
    {
        foreach (Rigidbody rb in _rigidbodies)
            rb.isKinematic = true;
    }

    public void DiedCreature()
    {
        foreach (Rigidbody rb in _rigidbodies)
            rb.isKinematic = false;
    }
}