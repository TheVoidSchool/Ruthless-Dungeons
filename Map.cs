using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public int mapSize;
    public Tile[,] map;
    public Sprite Wall, Room, Hall, Trap;
    public int tileChange = 0;

    public Vector2 point;
    public CameraMovement Cam;

    public Image W1, R1, H1, T1; // as in wall 1

    public Color selected;
    public Color unselcted;


    //point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

    void Start()
    {
        map = new Tile[mapSize, mapSize];
        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                map[i,j] = new Tile(this, (new Vector2Int(i, j)));
            }
        }
        SpawnTile();
    }

    // Update is called once per frame
    void Update()
    {
        point = Cam.cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (tileChange == 1)
            {
                map[(int)point.x, (int)point.y].tileType = 0;
                map[(int)point.x, (int)point.y].obj.GetComponent<SpriteRenderer>().sprite = Wall;
            }
            if (tileChange == 2)
            {
                map[(int)point.x, (int)point.y].tileType = 1;
                map[(int)point.x, (int)point.y].obj.GetComponent<SpriteRenderer>().sprite = Room;
            }
            if (tileChange == 3)
            {
                map[(int)point.x, (int)point.y].tileType = 2;
                map[(int)point.x, (int)point.y].obj.GetComponent<SpriteRenderer>().sprite = Hall;
            }
            if (tileChange == 4)
            {
                map[(int)point.x, (int)point.y].tileType = 3;
                map[(int)point.x, (int)point.y].obj.GetComponent<SpriteRenderer>().sprite = Trap;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            tileChange = 0;
            W1.color = unselcted;
            R1.color = unselcted;
            H1.color = unselcted;
            T1.color = unselcted;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            wall();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            room();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            hall();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            trap();
        }
    }

    void SpawnTile()
    {
        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                var go = Instantiate(new GameObject());
                var tile = go.AddComponent<SpriteRenderer>();
                go.transform.position = new Vector3((i + 0.5f), (j + 0.5f), 0);
                tile.sprite = map[i, j].tilePicture;
                map[i, j].obj = go;
            }
        }
    }

    void changeTile()
    {
        
    }

    public void wall()
    {
        if (tileChange == 1)
        {
            tileChange = 0;
            W1.color = unselcted;
        }
        else
        {
            tileChange = 1;
            W1.color = selected;
            R1.color = unselcted;
            H1.color = unselcted;
            T1.color = unselcted;
        }
    }
    public void room()
    {
        if (tileChange == 2)
        {
            tileChange = 0;
            R1.color = unselcted;
        }
        else
        {
            tileChange = 2;
            W1.color = unselcted;
            R1.color = selected;
            H1.color = unselcted;
            T1.color = unselcted;
        }
    }
    public void hall()
    {
        if (tileChange == 3)
        {
            tileChange = 0;
            H1.color = unselcted;
        }
        else
        {
            tileChange = 3;
            W1.color = unselcted;
            R1.color = unselcted;
            H1.color = selected;
            T1.color = unselcted;
        }
    }
    public void trap()
    {
        if (tileChange == 4)
        {
            tileChange = 0;
            T1.color = unselcted;
        }
        else
        {
            tileChange = 4;
            W1.color = unselcted;
            R1.color = unselcted;
            H1.color = unselcted;
            T1.color = selected;
        }
    }
}

public class Tile
{
    public int tileType;
    public Sprite tilePicture;
    public Vector2Int location;
    public GameObject obj; //as in object

    public Tile(Map m, Vector2Int n) 
    {
        tilePicture = m.Wall;
        tileType = 0;
        location = n;
    }
}