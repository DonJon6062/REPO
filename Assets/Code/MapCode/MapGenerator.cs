using System;
using System.Collections;
using System.Collections.Generic;
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

        public int mapSeed;
        bool isMapOfTheDay = false;
        #endregion Variables

        // Start is called before the first frame update
        void Start()
        {
            //GenerateMap();
        }

        public int DateToInt(DateTime dateToUse)
        {
            return dateToUse.Year + dateToUse.Month + dateToUse.Day + dateToUse.Hour + dateToUse.Minute + dateToUse.Second + dateToUse.Millisecond;
        }

        public GameObject RandomRoomPrefab()
        {
            return gridPrefabs[UnityEngine.Random.Range(0, gridPrefabs.Length)];
        }
        public void GenerateRandomMap()
        {
            GameManager.instance.SpawnPlayerOne();
            //make grid
            mapGrid = new Room[rows, cols];

            int totalRandomness = UnityEngine.Random.Range(0, 999999);
            UnityEngine.Random.InitState(DateToInt(DateTime.Now) + totalRandomness);
            Debug.Log(DateToInt(DateTime.Now) + totalRandomness);

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
                    mapGrid[currentCol, currentRow] = TempRoom;

                    //open/close doors; north and south
                    if (currentCol == 0)
                    {
                        TempRoom.doorNorth.SetActive(false);
                    }
                    else if (currentCol == cols - 1)
                    {
                        TempRoom.doorSouth.SetActive(false);
                    }
                    else
                    {
                        TempRoom.doorNorth.SetActive(false);
                        TempRoom.doorSouth.SetActive(false);
                    }

                    //east and west
                    if (currentRow == 0)
                    {
                        TempRoom.doorEast.SetActive(false);
                    }
                    else if (currentRow == rows - 1)
                    {
                        TempRoom.doorWest.SetActive(false);

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
        
        public void GenerateMapOfTheDay() 
        {
            GameManager.instance.SpawnPlayerOne();
            isMapOfTheDay = true;

            if (isMapOfTheDay)
            {
                mapSeed = DateToInt(DateTime.Now.Date);
                Debug.Log(DateToInt(DateTime.Now.Date));
            }
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
                    mapGrid[currentCol, currentRow] = TempRoom;

                    //open/close doors; north and south
                    if (currentCol == 0)
                    {
                        TempRoom.doorNorth.SetActive(false);
                    }
                    else if (currentCol == cols - 1)
                    {
                        TempRoom.doorSouth.SetActive(false);
                    }
                    else
                    {
                        TempRoom.doorNorth.SetActive(false);
                        TempRoom.doorSouth.SetActive(false);
                    }

                    //east and west
                    if (currentRow == 0)
                    {
                        TempRoom.doorEast.SetActive(false);
                    }
                    else if (currentRow == rows - 1)
                    {
                        TempRoom.doorWest.SetActive(false);

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