using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerDetectionArea : MonoBehaviour
{
    public Collider ducklingFollowArea;

    public Vector3 GetRandomPointInCollider()
    {
        var point = new Vector3(
            Random.Range(ducklingFollowArea.bounds.min.x, ducklingFollowArea.bounds.max.x),
            Random.Range(ducklingFollowArea.bounds.min.y, ducklingFollowArea.bounds.max.y),
            Random.Range(ducklingFollowArea.bounds.min.z, ducklingFollowArea.bounds.max.z)
        );

        if (point != ducklingFollowArea.ClosestPoint(point))
        {
            Debug.Log("Out of the collider! Looking for other point...");
            point = GetRandomPointInCollider();
        }

        return point;
    }
}
