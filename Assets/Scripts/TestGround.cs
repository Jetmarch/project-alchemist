using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestGround : MonoBehaviour
{
    private PlayerController player;

    [Header("Throw")]
    [SerializeField] private bool isThrowing;
    [SerializeField] private Transform throwObjectSpawn;
    [SerializeField] private Vector2 dragStartPos;
    [SerializeField] private float powerOfThrow;
    [SerializeField] private Item testItemForThrow;


    private void Start()
    {
        player = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        Throw();
    }

    public void Throw()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject currentThrowingObject = ItemWorldSpawner.SpawnItem(throwObjectSpawn.position, testItemForThrow);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 _velocity = (mousePosition - (Vector2)throwObjectSpawn.position) * powerOfThrow;

            if (currentThrowingObject != null)
            {
                currentThrowingObject.GetComponent<Rigidbody2D>().velocity = _velocity;
            }
        }
    }
}
