using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	[Tooltip("hi")] [SerializeField] float movementFactor = 10f;
	[SerializeField] float movementLimiter = 10f;

	bool isControlEnabled = true;

	void Start () {
		
	}
	
	void Update () {
		if (isControlEnabled) {
            ProcessInput();
        }
	}

	void ProcessInput () {
		float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		float zThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float xOffset = xThrow * movementFactor * Time.deltaTime;
		float clampedXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -Mathf.Abs(movementLimiter), movementLimiter);
		float zOffset = zThrow * movementFactor * Time.deltaTime;
        float clampedZPos = Mathf.Clamp(transform.localPosition.z + zOffset, -Mathf.Abs(movementLimiter), movementLimiter);
		// float jumped = CrossPlatformInputManager.GetAxis("Jump");

		transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, clampedZPos);
	}
}
