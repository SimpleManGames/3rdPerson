using Simplicity;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetSystemManager : Singleton<TargetSystemManager>
{
    public List<GameObject> targetableObjects;

    public List<GameObject> GetObjectsScreenByCamera(Camera camera)
    {
        return targetableObjects.Where(obj => CheckPoint(camera.WorldToViewportPoint(obj.transform.position))).ToList();
    }

    bool CheckPoint(Vector3 point)
    {
        if (point.x > 0 && point.x < 1 && point.y > 0 && point.y < 1 && point.z > 0)
            return true;

        return false;
    }
}