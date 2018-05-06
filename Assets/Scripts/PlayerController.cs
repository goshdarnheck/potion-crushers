using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	[Tooltip("How fast the player can move")] [SerializeField] float movementFactor = 10f;
	[Tooltip("How far the player can move from origin")] [SerializeField] float movementLimiter = 10f;
	[SerializeField] GameObject wandMagic;

	bool isControlEnabled = true;

	void Update () {
		if (isControlEnabled) {
            ProcessInput();
			ProcessFiring();
        }
	}

	void ProcessInput () {
		float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		float zThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float xThrowRaw = CrossPlatformInputManager.GetAxisRaw("Horizontal");
		float zThrowRaw = CrossPlatformInputManager.GetAxisRaw("Vertical");

		float xOffset = xThrow * movementFactor * Time.deltaTime;
		float clampedXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -Mathf.Abs(movementLimiter), movementLimiter);
		float zOffset = zThrow * movementFactor * Time.deltaTime;
        float clampedZPos = Mathf.Clamp(transform.localPosition.z + zOffset, -Mathf.Abs(movementLimiter), movementLimiter);

		transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, clampedZPos);

		if (xThrowRaw != 0 || zThrowRaw != 0) {
			Vector3 thing = Vector3.Normalize(new Vector3(xThrow, 0f, zThrow));

			if (thing != Vector3.zero) {
				transform.forward = Vector3.Normalize(new Vector3(xThrow, 0f, zThrow));
			}
		}
	}

	private void ProcessFiring() {
        if (CrossPlatformInputManager.GetButton("Fire1")) {
            ShootMagic();
        }
    }

    private void ShootMagic() {
		wandMagic.GetComponent<ParticleSystem>().Emit(1);
    }
}
