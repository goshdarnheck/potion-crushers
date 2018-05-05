﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController2 : MonoBehaviour {

	[Tooltip("How fast the player can move")] [SerializeField] float movementFactor = 10f;
	[Tooltip("How far the player can move from origin")] [SerializeField] float movementLimiter = 10f;

	bool isControlEnabled = true;

	void Start () {
		
	}
	
	void Update () {
		if (isControlEnabled) {
            ProcessInput();
        }
	}

	void ProcessInput () {
		float xThrow = CrossPlatformInputManager.GetAxis("Horizontal2");
		float zThrow = CrossPlatformInputManager.GetAxis("Vertical2");

		float xOffset = xThrow * movementFactor * Time.deltaTime;
		float clampedXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -Mathf.Abs(movementLimiter), movementLimiter);
		float zOffset = zThrow * movementFactor * Time.deltaTime;
        float clampedZPos = Mathf.Clamp(transform.localPosition.z + zOffset, -Mathf.Abs(movementLimiter), movementLimiter);

		transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, clampedZPos);

		if (xThrow != 0 || zThrow != 0) {
			transform.forward = Vector3.Normalize(new Vector3(xThrow, 0f, zThrow));
		}
	}
}