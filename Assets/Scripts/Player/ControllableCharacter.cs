using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ControllableCharacter : MonoBehaviour
{
    [SerializeField]
    private bool isMoving;

    [SerializeField]
    private float timeForOneTurn;

    [SerializeField]
    private SettingsManager settings;

    private void Start()
    {
        transform.position = new Vector3(settings.gridCellCenter, settings.gridCellCenter, 0f);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!isMoving)
            {
                Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
                List<Vector3> path = AStarPath.instance.FindPath(transform.position, mouseWorldPosition);
                if (path != null)
                {
                    StartCoroutine(MovePlayer(path));

                    for (int i = 0; i < path.Count - 1; i++)
                    {
                        Debug.DrawLine(path[i], path[i + 1], Color.red, 2, false);
                    }

                }
            }
        }
    }


    private IEnumerator MovePlayer(List<Vector3> path)
    {

        foreach (var moveVector in path)
        {
            isMoving = true;
            var previousPos = transform.position;
            var newPos = moveVector;

            float elapsedTime = 0f;
            while (transform.position != newPos)
            {
                transform.position = Vector3.Lerp(previousPos, newPos, elapsedTime / timeForOneTurn);
                elapsedTime += Time.deltaTime;
                yield return new WaitForSeconds(Time.deltaTime);
            }
            isMoving = false;
        }
    }
}
