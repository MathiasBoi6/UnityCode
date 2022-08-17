using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing : MonoBehaviour
{

    //Forsøgt at lave path algoritme
    //Gør så diagonal bliver prioriteret
    //Virker remove rigtigt?
    //



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FindPath();
        }
    }
    
    private void FindPath()
    {
        


        
        Node[,] mapArr = CreateMap.GetMapArr();

        Node startNode = mapArr[4, 4];
        Node endNode = mapArr[16, 16];

        // 1 is up, 2 is right, 3 is down, 4 is left.
        int[,] map = new int [CreateMap.mapSizeX, CreateMap.mapSizeZ];

        (int startX,int startZ) = startNode.GetIdentity();
        (int endX, int endZ) = endNode.GetIdentity();

        PathSortedList list = new PathSortedList();

        list.AddNode(1, startNode);


        //bool pathFound = false;
        int count = 0;
        //while (!pathFound)
        while (count < 50)
        {
            Node currentNode = list.Pop();

            currentNode.CustomColor(Color.cyan);

            (int x, int z) = currentNode.GetIdentity();

            int rightX = x + 1;
            int leftX = x - 1;
            int upZ = z - 1;
            int downZ = z + 1;


            if ((rightX < CreateMap.mapSizeX) && (map[rightX, z] == 0) && !mapArr[rightX, z].IsOccupied()) 
            {
                //Debug.Log("right " + (int)(System.Math.Pow(endX - rightX, 2) + System.Math.Pow(endZ - z, 2)));
                list.AddNode((int)(System.Math.Pow(endX - rightX, 2) + System.Math.Pow(endZ - z, 2)), mapArr[rightX, z]);
                map[rightX, z] = 2;
            }
            if ((leftX >= 0) && (map[leftX, z] == 0) && !mapArr[rightX, z].IsOccupied())
            {
                //Debug.Log("left " + (int)(System.Math.Pow(endX - leftX, 2) + System.Math.Pow(endZ - z, 2)));
                list.AddNode((int)(System.Math.Pow(endX - leftX, 2) + System.Math.Pow(endZ - z, 2)), mapArr[leftX, z]);
                map[leftX, z] = 4;
            }
            if ((upZ >= 0) && (map[x, upZ] == 0) && !mapArr[rightX, z].IsOccupied())
            {
                //Debug.Log("up " + (int)(System.Math.Pow(endX - x, 2) + System.Math.Pow(endZ - upZ, 2)));
                list.AddNode((int)(System.Math.Pow(endX - x, 2) + System.Math.Pow(endZ - upZ, 2)), mapArr[x, upZ]);
                map[x, upZ] = 1;
            }
            if ((downZ < CreateMap.mapSizeZ) && (map[x, downZ] == 0) && !mapArr[rightX, z].IsOccupied())
            {
                //Debug.Log("down " + (int)(System.Math.Pow(endX - x, 2) + System.Math.Pow(endZ - downZ, 2)));
                list.AddNode((int)(System.Math.Pow(endX - x, 2) + System.Math.Pow(endZ - downZ, 2)), mapArr[x, downZ]);
                map[x, downZ] = 3;
            }


            //pathFound = true;
            count++;
        }

    }

}
