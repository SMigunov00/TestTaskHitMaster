using UnityEngine;

public class WaypointToKillEnemy : MonoBehaviour
{
    [SerializeField] private int _numberEnemiesKilledToStartMovement;
    private int _numberEnemiesKilled;

    public void HandleNumberEnemiesKilled()
    {
        _numberEnemiesKilled++;
        if (_numberEnemiesKilled == _numberEnemiesKilledToStartMovement)
            EventManager.SendMovingPlayerToWaypoint();
    }
}