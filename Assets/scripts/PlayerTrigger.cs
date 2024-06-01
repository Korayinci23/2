using UnityEngine;
using UnityEngine.Events;


public class PlayerTrigger : MonoBehaviour
{
    public EnemyController enemyController;

    [SerializeField] UnityEvent onTriggerEnter;

    [SerializeField] UnityEvent onTriggerExit;

    public void OnTriggerEnter(Collider other)
    {

        onTriggerEnter.Invoke();

        // Check if the colliding object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Set the isAlerted flag in the EnemyController
            enemyController.isAlerted = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke();
    }
 
}
