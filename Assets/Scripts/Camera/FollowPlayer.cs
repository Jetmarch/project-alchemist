using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.transform.position + offset;
    }

}
