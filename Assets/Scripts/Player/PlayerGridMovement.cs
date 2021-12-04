using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 targetPosition;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float timeForOneTurn;

    [SerializeField]
    private bool isMoving;

    [Header("Collision sensors")]
    [SerializeField]
    private CollisionSensor upSensor;

    [SerializeField]
    private CollisionSensor downSensor;

    [SerializeField]
    private CollisionSensor leftSensor;

    [SerializeField]
    private CollisionSensor rightSensor;

    private void Update()
    {
        if(isMoving)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.W) && !upSensor.isActive)
        {
            StartCoroutine(MovePlayer(Vector3.up));
        }
        if(Input.GetKeyDown(KeyCode.S) && !downSensor.isActive)
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }
        if (Input.GetKeyDown(KeyCode.D) && !rightSensor.isActive)
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }
        if (Input.GetKeyDown(KeyCode.A) && !leftSensor.isActive)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }
    }

    private IEnumerator MovePlayer(Vector3 moveVector)
    {

        isMoving = true;

        var previousPos = transform.position;
        var newPos = transform.position + moveVector;

        float elapsedTime = 0f;
        while(transform.position != newPos)
        {
            transform.position = Vector3.Lerp(previousPos, newPos, elapsedTime / timeForOneTurn);
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        isMoving = false;
    }
}
