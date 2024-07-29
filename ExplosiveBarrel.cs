using UnityEngine;
using UnityEngine.UI;

public class ExplosiveBarrel : MonoBehaviour
{
    public int damage = 10;
    public float explosionDelay = 1f;
    public Text warningText;

    private int playerCollisionCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollisionCount++;
            if (playerCollisionCount == 1)
            {
                warningText.text = "Взрыв через " + explosionDelay + " секунд!";
                Invoke("Explode", explosionDelay);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollisionCount--;
            if (playerCollisionCount == 0)
            {
                warningText.text = "";
            }
        }
    }

    private void Explode()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
