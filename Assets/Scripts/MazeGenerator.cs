using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MazeGenerator : MonoBehaviour
{

    [SerializeField] GameObject wall;
    [SerializeField] GameObject floor;
    [SerializeField] NavMeshSurface surface;

    [SerializeField] int numberOfPaths = 2;
    [SerializeField] int x = 20;
    [SerializeField] int y = 10;
    [SerializeField] int minWalls = 50;
    // Start is called before the first frame update
    void Start()
    {
        surface.BuildNavMesh();
    }

	private void Awake()
	{
        BuildMaze();
	}

	private void BuildMaze()
    {

        List<List<int>> maze = new List<List<int>>();

        for (int i = 0; i < x; i++)
        {
            List<int> _list = new List<int>();
            maze.Add(_list);
            for (int j = 0; j < y; j++)
            {
                maze[i].Add(0);
            }
        }

        int[] rowDir = { 0, 1, 0, -1 };
        int[] colDir = { -1, 0, 1, 0 };

        List<List<int[]>> stack = new List<List<int[]>>();
        System.Random rand = new System.Random();

        for (int i = 0; i < numberOfPaths; i++)
        {
            int randRow, randCol;
            while (true)
            {
                randRow = rand.Next(0, x);
                randCol = rand.Next(0, y);
				if (maze[randRow][randCol] == 0)
				{
					break;
				}
			}
            List<int[]> _list = new List<int[]>();
            int[] arr = { randRow, randCol };
            _list.Add(arr);
            stack.Add(_list);
            maze[randRow][randCol] = i + 1;

        }



        bool check = true;
        while (check)
        {
            check = false;
            for (int i = 0; i < numberOfPaths; i++)
            {
                if (stack[i].Count > 0)
                {
                    check = true;
                    int[] point = stack[i][stack[i].Count - 1];
                    int currentRow = point[0];
                    int currentCol = point[1];
                    List<int> neighbours = new List<int>();

                    for (int j = 0; j < 4; j++)
                    {
                        int newRow = currentRow + rowDir[j];
                        int newCol = currentCol + colDir[j];
                        if (newRow >= 0 && newRow < x && newCol >= 0 && newCol < y)
                        {
                            if (maze[newRow][newCol] == 0)
                            {
                                int count = 0;
                                for (int k = 0; k < 4; k++)
                                {
                                    int checkRow = newRow + rowDir[k];
                                    int checkCol = newCol + colDir[k];
                                    if (checkRow >= 0 && checkRow < x && checkCol >= 0 && checkCol < y)
                                    {
                                        if (maze[checkRow][checkCol] == i + 1)
                                        {
                                            count += 1;
                                        }
                                    }
                                }
                                if (count == 1)
                                {
                                    neighbours.Add(j);
                                }
                            }
                        }
                    }
                    if (neighbours.Count > 0)
                    {
                        int possibleRoutes = neighbours[rand.Next(0, neighbours.Count)];
                        currentRow += rowDir[possibleRoutes];
                        currentCol += colDir[possibleRoutes];
                        maze[currentRow][currentCol] = i + 1;
                        int[] arr = { currentRow, currentCol };
                        stack[i].Add(arr);
                    }
                    else
                    {
                        stack[i].RemoveAt(stack[i].Count - 1);
                    }
                }
            }
        }

        int countBlocks = 0;
        for (int row = 0; row < x; row++)
        {
            for (int col = 0; col < y; col++)
            {
                if (maze[row][col] == 0)
                {
                    countBlocks++;
                }
            }

        }


        if(countBlocks < minWalls)
		{
            BuildMaze();
		}

        for (int row = 0; row < x; row++)
        {
            for (int col = 0; col < y; col++)
            {
                Vector3 position = new Vector3(row * 10f, 0, col * 10f);
                if (maze[row][col] == 0)
                {                
                    Instantiate(wall, position, Quaternion.identity);
                }
                Instantiate(floor, position, Quaternion.identity);
            }

        }

    }

}
