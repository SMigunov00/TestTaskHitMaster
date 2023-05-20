using System.Collections;
using UnityEngine;

public class ShotTouchingScreen : MonoBehaviour
{
    [SerializeField] private Transform _shotPosition;
    [SerializeField] private float _bulletLifetime;
    [SerializeField] private float _shotPower;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shot();
    }

    private void Shot()
    {
        GameObject bullet = Pool.Instance.GetPooledObject();
        if (bullet != null)
        {
            Ray bulletDirectionPoint = _mainCamera.ScreenPointToRay(Input.mousePosition);
            _shotPosition.rotation = Quaternion.LookRotation(bulletDirectionPoint.direction);
            bullet.transform.position = bulletDirectionPoint.origin;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody>().velocity = _shotPosition.transform.forward * _shotPower;
            StartCoroutine(BulletLifetime(bullet));
        }
    }

    private IEnumerator BulletLifetime(GameObject bullet)
    {
        yield return new WaitForSeconds(_bulletLifetime);
        bullet.SetActive(false);
    }
}