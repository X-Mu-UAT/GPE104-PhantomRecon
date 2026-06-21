using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipPawn : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float thrustForce = 500f;
    [SerializeField] private float yawSpeed = 90f;
    [SerializeField] private float pitchSpeed = 90f;
    [SerializeField] private float rollSpeed = 120f;

    [Header("Combat Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private float damageValue = 10f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MoveForward(float input)
    {
        if (Mathf.Abs(input) > 0.01f)
        {
            rb.AddForce(transform.forward * input * thrustForce * Time.deltaTime);
        }
    }

    public void RotateShip(float yawInput, float pitchInput, float rollInput)
    {
        float yaw = yawInput * yawSpeed * Time.deltaTime;
        float pitch = pitchInput * pitchSpeed * Time.deltaTime;
        float roll = rollInput * rollSpeed * Time.deltaTime;

        Quaternion rotationDelta = Quaternion.Euler(pitch, yaw, roll);
        rb.MoveRotation(rb.rotation * rotationDelta);
    }

    public void FireWeapon()
    {
        if (projectilePrefab != null && muzzlePoint != null)
        {
            GameObject proj = Instantiate(projectilePrefab, muzzlePoint.position, muzzlePoint.rotation);
            Projectile projectileScript = proj.GetComponent<Projectile>();
            if (projectileScript != null)
            {
                projectileScript.Initialize(damageValue);
            }
        }
    }
}

