using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InputManager : MonoBehaviour
{
    //[SerializeField] private GameObject arObj;
    [SerializeField] private Camera arCam;
    [SerializeField] ARRaycastManager _raycastManager;

    List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = arCam.ScreenPointToRay(Input.mousePosition);
            if (_raycastManager.Raycast(ray,_hits)){
                Pose pose = _hits[0].pose;
                Instantiate(DataHandler.Instance.furniture, pose.position, pose.rotation);
            }

        }
    }
}
