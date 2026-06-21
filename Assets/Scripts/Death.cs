using UnityEngine;

public class Death : MonoBehaviour
{

    public void OnDeath()
    {
        Debug.Log($"{gameObject.name} has been completly destroyed.");
        Destroy(gameObject );

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
