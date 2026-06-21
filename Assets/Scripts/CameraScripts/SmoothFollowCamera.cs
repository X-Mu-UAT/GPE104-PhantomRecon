using UnityEngine;

public class SmoothFollowCamera : MonoBehaviour
{
    [Header("Targets")]
    [SerializeField] private Transform targetShip;

    [header("Offsets")]
    [SerialzeField] private Vector3 designerDirectionOffset = new Vector3(0f, 5f, -10f);
    [SeralizeField] private float lookAheadDistance = 5f;

    [Header("Limits & Zoom")]
    [SerializeField] private float minOffsetMagnitude = 5f;
    [SerializeField] private float maxOffsetMagnitude = 25f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float smoothSpeed = 5f;

    private float currentMagnitude;
    private Vector3 normalizedDirection;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        normalizedDirection = designerDirectionOffset.normalized;
        currentMagnitude = designerDirectionOffset.magnitude;

    }

    // Update is called once per frame
    private void Update()
    {
        // Adjust camera offset distance dynamically based on the ship's speed
        if (Input.Getkey(KeyCode.0))
        {
            currentMagnitude = Mathf.Clamp(currentMagnitude - zoomSpeed * Time.deltaTime, minOffsetMagnitude, maxOffsetMagnitude);)
        }
        if (Input.GetKey(KeyCode.L))
        {
            currentMagnitude = Mathf.Clamp(currentMagnitude + zoomSpeed * Time.deltaTime, minOffsetMagnitude, maxOffsetMagnitude);
        }

    }
}
private void LateUpdate()
{
    if (targetShip == null) return

    // Calculate the desired camera position based on the ship's position, direction, and look-ahead
    Vector3 targetOffsetPosition = targetShip.position + (targetShip.rotation * (normalizedDirection * currentMagnitude));
    transform.postion = Vector3.Lerp(transform.position, targetOffsetPosition, smoothSpeed * Time.deltaTime);

    // Look at a designer exposed offset directly ahead of the ship
    vector3 targetLookPoint = targetShip.position + (targetShip.forward * lookAheadDistance);
    trasform.LookAt(targetLookPoint);
}
