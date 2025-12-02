using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using System.Collections;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARAnchorManager))]
public class AnchorCreator : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private ARAnchorManager anchorManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Pose hitPose;

    [SerializeField] private GameObject anchorPrefab;
    private void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        anchorManager = GetComponent<ARAnchorManager>();
    }
    private void Update()
    {
        
    }
}
