/*
 Created by: Mark Ryder
 Contributions:
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    const int gridSize = 10;
    public bool isExplored = false;
    public bool isTraverable = true;
    public Node exploredFrom;


	private void UpdateColor()
	{
		if (isExplored)
		{
            SetTopColor(Color.blue);
        }
	}

	public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int
            (
                Mathf.RoundToInt(transform.position.x / gridSize),
                Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }

    public void SetTopColor(Color color)
    {
        transform.Find("Top").GetComponent<MeshRenderer>().material.color = color;
    }
}
