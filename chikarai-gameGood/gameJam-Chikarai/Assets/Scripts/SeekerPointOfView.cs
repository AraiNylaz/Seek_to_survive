using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SeekerPointOfView : MonoBehaviour
{

    public Transform player;
    [FormerlySerializedAs("m_isPlayerInSight")] public bool _isPlayerInSight;
    [SerializeField] private UnityEvent gameOver;


    public void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            _isPlayerInSight = true;
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            _isPlayerInSight = false;
        }
    }

    public void Update()
    {
        if (_isPlayerInSight)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            
            if(Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameOver.Invoke();
                }
            }
            
        }
        
    }
    
}