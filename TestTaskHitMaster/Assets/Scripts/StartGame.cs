using TMPro;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _openingText;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            _openingText.enabled = false;
            EventManager.SendMovingPlayerToWaypoint();
            this.enabled = false;
        }
    }
}