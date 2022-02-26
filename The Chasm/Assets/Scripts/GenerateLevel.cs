using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{

    public Transform[] spawnRoomPosition;
    public GameObject[] Rooms;

    int[] MapTracker;
    public int gridX;
    public int gridY;
    int index = 0;

    float time;
    float startTime = 0.1f;

    enum RoomTypes // Types of rooms used to generate level
    {
        Sides,
        SidesDown,
        SidesTop,
        Open,
        Block,
        Start,
        End
    }

    RoomTypes newRoom;

    enum Directions // Directions in which generator can move
    {
        Right = 1,
        Left = 2,
        Down = 3
    }

    Directions currentDirection; // Curent direction of the generator
    Directions previousDirection; // Previous direction of the generator
    

    // Boundries set for generator
    public int maxLeft;
    public int maxRight;
    public int stopGenPos;


    bool stopGenerator = false; // Variable to check if the generation of the critical path is finished

    void Start()
    {
        MapTracker = new int[spawnRoomPosition.Length];
        index = 0;
        MapTracker[index] = 1;

        transform.position = spawnRoomPosition[index].position;
        currentDirection = Directions.Right;
        Instantiate(Rooms[(int)RoomTypes.Start], transform.position, Quaternion.identity);

        // Find first direction in which generator will move
        

    }

    void Update()
    {

        if (!stopGenerator)
        {           
            MoveGenerator();
            time = startTime;
        }
        else
        {
            time -= Time.deltaTime;
        }

    }

    void MoveGenerator()
    {
        if (currentDirection == Directions.Right)
        {
            index += 1;
            MapTracker[index] = 1;
        }

        else if (currentDirection == Directions.Left)

        {
            index -= 1;
            MapTracker[index] = 1;

        }

        else if (currentDirection == Directions.Down)
        {
            if (transform.position.y > stopGenPos)
            {
                index += gridX;
                MapTracker[index] = 1;
            }

            else
            {
                stopGenerator = true;
                MapTracker[index] = 2;            
                FillMap(MapTracker);
                
            }

        }
        
        Vector2 newPos = spawnRoomPosition[index].position;

        transform.position = newPos;
        previousDirection = currentDirection;
        currentDirection = GetNewDirection(previousDirection);


        newRoom = FindRoomType(currentDirection, previousDirection);
        
        if (!stopGenerator)
        {
            Instantiate(Rooms[(int)newRoom], transform.position, Quaternion.identity);
            MapTracker[index] = 1;
        }
        
    }

    // Find type of the room
    RoomTypes FindRoomType(Directions direction, Directions previousDir)
    {
        RoomTypes generatedRoom;

        if(previousDir != Directions.Down)
        {
            if(direction != Directions.Down)
            {
                int[] sideDirArray = new int[] {0, 1, 3 };
                generatedRoom = RoomTypes.Sides; // (RoomTypes)sideDirArray[Random.Range(0, sideDirArray.Length)];
                
                Debug.Log(direction);

            }

            else if (direction == Directions.Down && transform.position.y <= stopGenPos)
            {
                generatedRoom = RoomTypes.End;
            }

            else
            {
                int[] downDirArray = new int[] { 1, 3 };
                generatedRoom = (RoomTypes)downDirArray[Random.Range(0, downDirArray.Length)];
                
                Debug.Log(direction);
            }
        }
        else
        {
            if(direction != Directions.Down)
            {
                int[] prevDownArray = new int[] { 2, 3 };
                generatedRoom = RoomTypes.Open;
            }

            else if(direction == Directions.Down && transform.position.y <= stopGenPos)
            {
                generatedRoom = RoomTypes.End;
            }
            else
            {
                generatedRoom = RoomTypes.Open;
            }
        }

        return generatedRoom;
    }


    // Generate new direction for the generator
    Directions GetNewDirection(Directions previous)
    {
        Directions newDirection = Directions.Down;
        int random = Random.Range(1, 6);
        switch (previous)
        {
            case Directions.Right:
                if (random < 4)
                {                    
                    if (transform.position.x  < maxRight)
                    {
                        newDirection = Directions.Right;
                    }                 
                }
                break;
            case Directions.Left:
                if (random < 4)
                {
                    if (transform.position.x > maxLeft)
                    {
                        newDirection = Directions.Left;
                    }
                }
                break;
            case Directions.Down:
                switch (random)
                {
                    case 1:
                    case 2:
                        if (transform.position.x > maxLeft)
                        {
                            newDirection = Directions.Left;
                        }                      
                        break;
                    case 3:
                    case 4:
                        if (transform.position.x < maxRight)
                        {
                            newDirection = Directions.Right;
                        }                      
                        break;
                    default:
                        newDirection = Directions.Down;
                        break;
                }
                break;
        }

        return newDirection;
    }

    // Fill rest of the level with random rooms
    void FillMap(int[] array)
    {
        for (int i = 0; i< array.Length; i++)
        {
            RoomTypes randomRoom;
            Transform spawnPosition;
            if (array[i] == 0)
            {
                randomRoom = (RoomTypes)Random.Range(0, 5);
                spawnPosition = spawnRoomPosition[i];
                transform.position = spawnPosition.position;
                Instantiate(Rooms[(int)randomRoom], transform.position, Quaternion.identity);

            }
        }
       
    }
}
