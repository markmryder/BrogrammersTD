using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class ShowMazeGeneration : MonoBehaviour
{
    [SerializeField] int minWalls = 30;
    [SerializeField] NavMeshSurface surface;
    [SerializeField] int path = 2;



    void Start()
    {
    }
        
        
    private void Awake()
    {
        BuildWallAndFloor();

    }

    public void StartStuff()
	{
        StartCoroutine(DestroyWalls());     
    }

    public IEnumerator DestroyWalls()
	{
        print("start of coroutine");
        //grid size
        int gridRow = 20;
        int gridCol = 10;
        //number of paths
        int seed = System.Guid.NewGuid().GetHashCode();
        //int seed = 12464509;
        System.Random rand = new System.Random(seed);
        print(seed);

        //int path = 2;
        //-------------------------------------------makes grid
        int[,] grid = new int[gridRow, gridCol];
        grid.Initialize();
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
        print("hi outside loop");
        while (check)
        { //keep performing until stack is empty
            yield return new WaitForSeconds(1);
            print("hi");
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
                        

                        var block = GameObject.Find("Cube: "+nextRow+","+nextCol);
                        Destroy(block);
                        print(block);
                    }
                    else
                    {
                        stack[i].RemoveAt(stack[i].Count - 1);
                    }
                }
            }
        }
    }


    private void BuildWallAndFloor()
	{

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 10; j++)
            {


                GameObject floor = (GameObject)Resources.Load("QuadCube");
                Instantiate(floor);
                Vector3 positionTwo = new Vector3(i * 10f, 0, j * 10f);
                floor.transform.position = positionTwo;

            }
        }
    }
    private void BuildGrid()
    {
        //grid size
        int gridRow = 20;
        int gridCol = 10;
        //number of paths
        int seed = System.Guid.NewGuid().GetHashCode();
        //int seed = 12464509;
        System.Random rand = new System.Random(seed);
        print(seed);

        //int path = 2;
        //-------------------------------------------makes grid
        int[,] grid = new int[gridRow, gridCol];
        grid.Initialize();
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
                        var destroyBlock = GameObject.Find("Cube: "+nextRow+","+nextCol);
                        Destroy(destroyBlock);
                        print(destroyBlock);
                    }
                    else
                    {
                        stack[i].RemoveAt(stack[i].Count - 1);
                    }
                }
            }
        }
        //----------------------------------draw final grid


    }

    // Update is called once per frame
    void Update()
    {

    }
}
