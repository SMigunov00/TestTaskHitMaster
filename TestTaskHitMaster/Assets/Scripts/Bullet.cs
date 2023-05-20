using Extensions;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{    
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        collision.gameObject.HandleComponent<Enemy>((component) => component.ApplyDamage());
    }
}