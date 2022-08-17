using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public const int mapSizeX = 20;
    public const int mapSizeZ = 20;
    public GameObject groundTile;
    public GameObject flagObj;
    private static Node[,] mapArr = new Node[mapSizeX, mapSizeZ];
    private static List<GameObject> flags = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateField(mapSizeX, mapSizeZ);



    }

    //Private methods

    private void CreateField(int x, int z)
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < z; j++)
            {
                GameObject Tile = Instantiate(groundTile, new Vector3(i, 0, j), Quaternion.identity);
                Tile.transform.parent = this.transform;
                Tile.GetComponent<Node>().SetIdentity(i, j);
                mapArr[i, j] = Tile.GetComponent<Node>();
            }
        }
        
        
        System.Random rand = new System.Random();
        //Amount of flags
        int flagAmount = rand.Next(2, 6);


        //Flatten map array and chose random. Rember which index was chosen.
        //Maybe change to array for faster
        List<int> chosenNodes = new List<int>();

        int flagX = x - 1;
        int flagZ = z - 1;
        int nodeAmount = flagX * flagZ;
        for (int i = 0; i < flagAmount; i++)
        {
            int choice = rand.Next(0, nodeAmount + 1 - chosenNodes.Count);
            foreach (int node in chosenNodes)
            {
                if (choice > node)
                {
                    choice++;
                }
            }
            chosenNodes.Add(choice);
            chosenNodes.Sort();
        }
        foreach (int node in chosenNodes)
        {
            //Debug.Log("Node num: " + node + ", Position: " + node % flagX + ", " + Mathf.Floor(node / flagX));
            Instantiate(flagObj, new Vector3(node % flagX, 0, Mathf.Floor(node / flagX)), Quaternion.LookRotation(Vector3.right));
        }
    }




    //Public methods

    public static Node[,] GetMapArr()
    {
        return mapArr;
    }

    public static List<Node> GetSquare(MapSelection MS1, MapSelection MS2)
    {
        List<Node> NodeList = new List<Node>();
        int leftMost = MS1.value.Value.Item1;
        int topMost = MS1.value.Value.Item2;
        int rightMost = MS2.value.Value.Item1;
        int bottomMost = MS2.value.Value.Item2;
        //Debug.Log("L was: " + leftMost + ". R was: " + rightMost + ". T was: " + topMost + ". B was: " + bottomMost);

        for (int i = leftMost; i <= rightMost; i++)
        {
            for(int j = bottomMost; j <= topMost; j++)
            {
                NodeList.Add(mapArr[i, j]);
            }
        }

        return NodeList;
    }
}
