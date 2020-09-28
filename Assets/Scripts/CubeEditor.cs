using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Node))]
public class CubeEditor : MonoBehaviour
{

    
    Node node;

    private void Awake()
    {
        node = GetComponent<Node>();
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = node.GetGridSize();

        transform.position = new Vector3
        (
            node.GetGridPos().x * gridSize,
            0f, 
            node.GetGridPos().y * gridSize
        );
    }

    private void UpdateLabel()
    {
        Vector2Int gridPosition = node.GetGridPos();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = (gridPosition.x) + "," + (gridPosition.y);
        textMesh.text = labelText;
        gameObject.name = "Cube: " + labelText;
    }
}
