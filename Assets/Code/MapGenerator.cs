using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

namespace AAA
{
    public class MapGenerator : MonoBehaviour
    {

        #region Variables
        public GameObject[] gridPrefabs;
        public int rows;
        public int cols;
        public float RoomWidth = 50.0f;
        public float RoomHeight = 50.0f;
        private Room[,] mapGrid;
        #endregion Variables

        // Start is called before the first frame update
        void Start()
        {
            GenerateMap();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public GameObject RandomRoomPrefab()
        {
            return gridPrefabs[Random.Range(0, gridPrefabs.Length)];
        }
        public void GenerateMap()
        {
            //make grid
            mapGrid = new Room[rows, cols];

            #region Spawn Room Tiles

            //    //for every row
            for (int currentRow = 0; currentRow < rows; currentRow++)
            {
                //for every column
                for (int currentCol = 0; currentCol < cols; currentCol++)
                {
                    //figure out location
                    float XPosition = RoomWidth * currentRow;
                    float ZPosition = RoomHeight * currentCol;
                    Vector3 newPosition = new Vector3(XPosition, 0, ZPosition);

                    //place tile
                    GameObject TempRoomObj = Instantiate(RandomRoomPrefab(), newPosition, Quaternion.identity) as GameObject;

                    //set parent
                    TempRoomObj.transform.parent = transform;

                    //name it
                    TempRoomObj.name = "Room_" + "(" + currentRow + "," + currentCol + ") ";

                    //get room.cs script from it
                    Room TempRoom = TempRoomObj.GetComponent<Room>();

                    //save it to the array
                    mapGrid[currentRow, currentCol] = TempRoom;

                    //open/close doors; north and south
                    if (currentRow == 0)
                    {
                        TempRoom.doorNorth.SetActive(false);
                    }
                    else if (currentRow == rows - 1)
                    {
                        TempRoom.doorSouth.SetActive(false);
                    }
                    else
                    {
                        TempRoom.doorNorth.SetActive(false);
                        TempRoom.doorSouth.SetActive(false);
                    }

                    //east and west
                    if (currentCol == 0)
                    {
                        TempRoom.doorWest.SetActive(false);
                    }
                    else if (currentCol == cols - 1)
                    {
                        TempRoom.doorEast.SetActive(false);
                    }
                    else
                    {
                        TempRoom.doorWest.SetActive(false);
                        TempRoom.doorEast.SetActive(false);
                    }
                }
            }
            #endregion Spawm Room Tiles

        }

    }
}