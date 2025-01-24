using UnityEngine;
public class WallScript : MonoBehaviour
{
    public BoxCollider boxCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check for a collision with a specific object or tag
        if (collision.gameObject.CompareTag("Ball"))
        {
            boxCollider.enabled = false;
            Invoke("enableCollider", 2f );
        }
    }

    void enableCollider(){
        boxCollider.enabled = true;
    }
}
