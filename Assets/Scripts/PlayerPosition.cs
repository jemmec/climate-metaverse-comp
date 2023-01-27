using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Player Helper
/// Attach this script to the Player Controller / HMD
/// Used by the waypoint system to locate the player and determin 
/// if they are inside the way point.
/// </summary>
public class PlayerPosition : MonoBehaviour
{

    [SerializeField, Tooltip("A reference to the boxcollider around the player")]
    private BoxCollider _playerCollider;


    /// <summary>
    /// Holds a reference to the player cache so it doesn't continiously FindObjectOfType
    /// </summary>
    private static PlayerPosition _internalPlayerCache;
    private static PlayerPosition PlayerCache
    {
        get {
            if(_internalPlayerCache == null)
                _internalPlayerCache = FindObjectOfType<PlayerPosition>();
            return _internalPlayerCache;
        }
    }

    public static bool TryGetPlayerTransform(out Transform transform)
    {
        transform = default(Transform);
        if (PlayerCache)
        {
            transform = PlayerCache.transform;
            return true;
        }
        return false;
    }

    public static bool TryGetPlayerWorldPosition(out Vector3 worldPosition)
    {
        worldPosition = Vector3.zero;
        Transform transform;
        if (TryGetPlayerTransform(out transform))
        {
            worldPosition = transform.position;
            return true;
        }
        return false;
    }

    public static bool TryGetPlayerLocalPosition(out Vector3 localPosition)
    {
        localPosition = Vector3.zero;
        Transform transform;
        if (TryGetPlayerTransform(out transform))
        {
            localPosition = transform.localPosition;
            return true;
        }
        return false;
    }

    public static bool TryGetPlayerBoxCollider(out BoxCollider boxCollider)
    {
        boxCollider = default(BoxCollider);
        if (PlayerCache)
        {
            if (PlayerCache._playerCollider)
            {
                boxCollider = PlayerCache._playerCollider;
                return true;
            }
        }
        return false;
    }

}
