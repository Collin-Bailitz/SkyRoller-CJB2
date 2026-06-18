using UnityEngine;

public class Hazard : MonoBehaviour
{
    public enum HazardType
    {
        InstantLose,
        SlowDown,
        ReverseControls
    }

    public HazardType hazardType;

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Player")) return;

        PlayerMovement player = collider.GetComponent<PlayerMovement>();

        if (hazardType == HazardType.InstantLose)
        {
            GameManager.instance.LoseGame();
        }
        else if (hazardType == HazardType.SlowDown && player != null)
        {
            player.ActivateSpeedBoost(4f, 2f);
        }
        else if (hazardType == HazardType.ReverseControls && player != null)
        {
            player.ActivateReverseControls(3f);
        }
    }
}