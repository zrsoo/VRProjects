using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera _camera;
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // unity look at mouse https://forum.unity.com/threads/how-do-i-look-at-the-mouse-position-3d.542838/ 
        var lookAtPos = Input.mousePosition;
        var transform1 = transform;
        var transformPosition = transform1.position;
        
        lookAtPos.z -= _camera.transform.position.y - transformPosition.y;
        lookAtPos = _camera.ScreenToWorldPoint(lookAtPos);
        transform1.right = lookAtPos - transformPosition;
    }
}
