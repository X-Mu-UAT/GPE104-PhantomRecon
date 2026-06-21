using UnityEngine;
// 1. You must add this namespace line at the top to access new input utilities
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [SerializeField] private ShipPawn targetPawn;

    private void Update()
    {
        if (targetPawn == null) return;

        // --- Thrust: W and D ---
        float thrustInput = 0f;
        if (Keyboard.current.wKey.isPressed) thrustInput += 1f;
        if (Keyboard.current.dKey.isPressed) thrustInput -= 1f;

        // --- Yaw: A and S ---
        float yawInput = 0f;
        if (Keyboard.current.aKey.isPressed) yawInput -= 1f;
        if (Keyboard.current.sKey.isPressed) yawInput += 1f;

        // --- Roll: Q and E ---
        float rollInput = 0f;
        if (Keyboard.current.qKey.isPressed) rollInput += 1f;
        if (Keyboard.current.eKey.isPressed) rollInput -= 1f;

        // --- Pitch: Z and X ---
        float pitchInput = 0f;
        if (Keyboard.current.zKey.isPressed) pitchInput += 1f;
        if (Keyboard.current.xKey.isPressed) pitchInput -= 1f;

        // Send mechanical data down to pawn execution loop
        targetPawn.MoveForward(thrustInput);
        targetPawn.RotateShip(yawInput, pitchInput, rollInput);

        // --- Shooting Actions ---
        // Spacebar click or Left Mouse Button click triggers weapon
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Pointer.current.press.wasPressedThisFrame)
        {
            targetPawn.FireWeapon();
        }
    }
}

