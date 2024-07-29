using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public Text coinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.AddCoins(value);
                Destroy(gameObject);
            }
        }
    }
}
