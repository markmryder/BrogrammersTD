
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    [SerializeField] int minWalls = 30;
    // Start is called before the first frame update

    void Start()
    { 
    
    }
    private void Awake()
    {
        BuildGrid();
    }
    private void BuildGrid()
    {
        //grid size
        int gridRow = 10;
        int gridCol = 20;
        //number of paths
        System.Random rand = new System.Random(System.Guid.NewGuid().GetHashCode());
        int path = 2;
        //-------------------------------------------makes grid
        int[,] grid = new int[gridRow, gridCol];
        for (int i = 0; i < gridRow; i++)
        {
            for (int j = 0; j < gridCol; j++)
            {
                grid[i, j] = 0;
                //Console.Write(grid[i, j]);
            }
            //Console.Write("\n");
        }
        //-------------------------------------------pick random spots to start
        Dictionary<int, List<(int, int)>> stack = new Dictionary<int, List<(int, int)>>();
        for (int i = 0; i < path; i++)
        {
            int randRow = rand.Next(gridRow);
            int randCol = rand.Next(gridCol);
            grid[randRow, randCol] = i + 1;
            stack.Add(i, new List<(int, int)> { (randRow, randCol) });
        }

        //--------------------------------------------Create Paths
        //set direction
        int[] rowDir = { 0, 1, 0, -1 };
        int[] colDir = { -1, 0, 1, 0 };
        bool check = true;
        while (check)
        { //keep performing until stack is empty
            check = false;
            for (int i = 0; i < path; i++)  //loops through # of paths
            {
                if (stack[i].Count > 0)
                {
                    check = true;
                    List<int> neighbour = new List<int>();
                    //get the last element(coord) in the list for each path
                    int currentRow = stack[i].Last().Item1;
                    int currentCol = stack[i].Last().Item2;
                    for (int j = 0; j < 4; j++) //check neighbour 
                    {
                        int newRow = currentRow + rowDir[j];
                        int newCol = currentCol + colDir[j];
                        //keeps it in range of grid
                        if (newRow >= 0 && newRow < gridRow && newCol >= 0 && newCol < gridCol)
                        {
                            if (grid[newRow, newCol] == 0)
                            {
                                int count = 0;
                                for (int k = 0; k < 4; k++)//check if next to path
                                {
                                    int checkRow = newRow + rowDir[k];
                                    int checkCol = newCol + colDir[k];
                                    if (checkRow >= 0 && checkRow < gridRow && checkCol >= 0 && checkCol < gridCol)
                                    {
                                        //checks if next to same path, if not add as possible route
                                        if (grid[checkRow, checkCol] == i + 1)
                                        {
                                            count++;
                                        }
                                    }
                                }
                                if (count == 1) //if connected to the path only once
                                {
                                    neighbour.Add(j);//adds possible direction
                                }
                            }
                        }
                    }
                    if (neighbour.Count > 0) // checks possible neighbours
                    {
                        int possibleRoutes = neighbour.Count;
                        //int nextDir = neighbour[rand.Next(0, possibleRoutes -1)];
                        int nextDir = neighbour[rand.Next(0, possibleRoutes)];
                        int nextRow = currentRow + rowDir[nextDir];
                        int nextCol = currentCol + colDir[nextDir];
                        grid[nextRow, nextCol] = i + 1; //sets position on grid
                        stack[i].Add((nextRow, nextCol));
                    }
                    else
                    {
                        stack[i].RemoveAt(stack[i].Count - 1);
                    }
                }
            }
        }
        //----------------------------------draw final grid

        int countBlocks = 0;
        for (int row = 0; row < gridRow; row++)
        {
            for (int col = 0; col < gridCol; col++)
            {
                if (grid[row,col] == 0)
                {
                    countBlocks++;
                }
            }

        }

        if (countBlocks < minWalls)
        {
            BuildGrid();
        }

        for (int i = 0; i < gridRow; i++)
        {
            for (int j = 0; j < gridCol; j++)
            {
                if (grid[i, j] == 0)
                {
                    GameObject obstacle = (GameObject)Resources.Load("Wall");
                    Instantiate(obstacle);
                    Vector3 position = new Vector3(i * 10f, 0, j * 10f);
                    obstacle.transform.position = position;
                }
                GameObject floor = (GameObject)Resources.Load("QuadCube");
                Instantiate(floor);
                Vector3 positionTwo = new Vector3(i * 10f, 0, j * 10f);
                floor.transform.position = positionTwo;

                //Console.Write(grid[i, j]);
            }
           // Console.Write("\n");
        }
        GameObject floorStart = (GameObject)Resources.Load("QuadCube");
        Instantiate(floorStart);
        Vector3 positionThree = new Vector3(9 * 10f, 0, 19 * 10f);
        floorStart.transform.position = positionThree;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
