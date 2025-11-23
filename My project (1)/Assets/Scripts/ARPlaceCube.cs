using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.XR.ARSubsystems;

public class ARPlaceCube : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
    bool isPlacing = false;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
    
    void Update()
    {
        if (!raycastManager) return;
        if (isPlacing) return;

        bool pressed = false;
        Vector2 screenPosition = default;

        
            

            if(Touchscreen.current != null)
            {
                var primary = Touchscreen.current.primaryTouch;
                if (primary.press.wasPressedThisFrame)
                {
                    pressed = true;
                    screenPosition = primary.position.ReadValue();

                }

               
            }
            else if(Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) 
            {
                pressed = true;
                screenPosition = Mouse.current.position.ReadValue();
            }

            if(pressed)
            {
                isPlacing = true;
                PlaceObject(screenPosition);
            }
        
    }

    void PlaceObject(Vector2 touchPosition)
    {
        var rayHits = new List<ARRaycastHit>();
        raycastManager.Raycast(touchPosition, rayHits, UnityEngine.XR.ARSubsystems.TrackableType.AllTypes);

        if (rayHits.Count > 0 )
        {
            Vector3 hitPosePosition = rayHits[0].pose.position;
            Quaternion hitPoseRotation = rayHits[0].pose.rotation;
            Instantiate(raycastManager.raycastPrefab, hitPosePosition, hitPoseRotation);
        }

        StartCoroutine(SetIsPlacingToFalseWithDelay());
    }

    System.Collections.IEnumerator SetIsPlacingToFalseWithDelay()
    {
        yield return new WaitForSeconds(0.25f);
        isPlacing = false;
    }
}
