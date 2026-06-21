using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform player;
    public float yPosition = -5f;

    void Update()
    {
        if (player == null) return;

        transform.position = new Vector3(
            player.position.x,
            yPosition,
            player.position.z
        );
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameManager.instance.LoseGame();
        }
    }
}