using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Vector3 ScreenToWorld(Camera cam, Vector3 position)
    {
        Ray ray = cam.ScreenPointToRay(position);
        if(Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            Vector3 point = raycastHit.point;
            return new Vector3(point.x, point.z);
        }    
        else return Vector3.zero;
    }
}
