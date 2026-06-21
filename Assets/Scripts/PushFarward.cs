using UnityEngine;

public class PushFarward : MonoBehaviour
{

    private Rigidbody rb;
    private Transform tf;
    public float pushForce;

    void Awake()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    // The short way of doing all this is to simply say rb.AddForce(transform.forward * pushForce);
    {

        Vector3 pushVector;
        // The short way to type is is pushVector = transform.forward;
        pushVector = GetComponent<Transform>().forward;
        pushVector*= pushForce;


        rb.AddForce(pushVector);
    }
}
