using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _timeToDestroyEnemy;
    [SerializeField] private Animator _animator;

    public UnityEvent<float> HitEvent;
    public UnityEvent DiedEvent;

    private void Start()
    {
        HitEvent?.Invoke(_health);
    }

    public void ApplyDamage()
    {
        _health--;
        HitEvent?.Invoke(_health);
        if (_health <= 0)
            DiedEvent?.Invoke();
    }

    public void EnemyDead() => StartCoroutine(Die());

    private IEnumerator Die()
    {
        transform.GetComponent<Collider>().enabled = false;
        _animator.enabled = false;
        yield return new WaitForSeconds(_timeToDestroyEnemy);
        gameObject.SetActive(false);
    }
}