using UnityEngine;

public class UniversalCamera : MonoBehaviour
{
    [Header("Targets")]
    [SerializeField] private Transform targetShip;

    [Header("Offsets")]
    [SerializeField] private Vector3 designerDirectionOffset = new Vector3(0f, 5f, -10f);
    [SerializeField] private float lookAheadDistance = 5f;

    [Header("Limits & Zoom")]
    [SerializeField] private float minOffsetMagnitude = 5f;
    [SerializeField] private float maxOffsetMagnitude = 25f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float smoothSpeed = 5f;

    private float currentMagnitude;
    private Vector3 normalizedDirection;

    private void Start()
    {
        normalizedDirection = designerDirectionOffset.normalized;
        currentMagnitude = designerDirectionOffset.magnitude;
    }

    private void Update()
    {
        // Check if the keyboard is connected and available
        if (UnityEngine.InputSystem.Keyboard.current != null)
        {
            // Adjust camera offset distance dynamically 
            if (UnityEngine.InputSystem.Keyboard.current.oKey.isPressed)
            {
                currentMagnitude = Mathf.Clamp(currentMagnitude - zoomSpeed * Time.deltaTime, minOffsetMagnitude, maxOffsetMagnitude);
            }

            if (UnityEngine.InputSystem.Keyboard.current.lKey.isPressed)
            {
                currentMagnitude = Mathf.Clamp(currentMagnitude + zoomSpeed * Time.deltaTime, minOffsetMagnitude, maxOffsetMagnitude);
            }
        }
    }


    private void LateUpdate()
    {
        if (targetShip == null) return;

        // Calculate custom positions based on current magnitude limits
        Vector3 targetOffsetPosition = targetShip.position + (targetShip.rotation * (normalizedDirection * currentMagnitude));
        transform.position = Vector3.Lerp(transform.position, targetOffsetPosition, smoothSpeed * Time.deltaTime);

        // Look at a designer-exposed offset directly ahead of ship path
        Vector3 targetLookPoint = targetShip.position + (targetShip.forward * lookAheadDistance);
        transform.LookAt(targetLookPoint);
    }
}
