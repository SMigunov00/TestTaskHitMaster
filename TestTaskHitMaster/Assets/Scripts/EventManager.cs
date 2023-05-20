using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static readonly UnityEvent OnMovingPlayerToWaypoint = new UnityEvent();

    public static void SendMovingPlayerToWaypoint() => OnMovingPlayerToWaypoint?.Invoke();
}