using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarPathInit : MonoBehaviour
{
    [SerializeField]
    private SettingsManager settings;
    // Start is called before the first frame update
    void Start()
    {
        var pathfinding = new AStarPath(5, 5, settings.gridCellSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
