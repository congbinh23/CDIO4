using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tileMapReadController : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] List<tileData> tileDatas;
    Dictionary<TileBase, tileData> dataFromTiles;

    private void Start()
    {
        dataFromTiles = new Dictionary<TileBase, tileData>();
        
        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile,tileData);
            }
        }
    }


    public Vector3Int getGridPosition(Vector2 position,bool mousePosition)
    {
        Vector3 worldPosition;
        if (mousePosition)
        {
            worldPosition = position;
        }
        else {
            worldPosition = Camera.main.ScreenToWorldPoint(position);
        }
        Vector3Int gridPosition = tilemap.WorldToCell(worldPosition);
        return gridPosition;
    }

    public TileBase getTileBase(Vector3Int gridPosition)
    {
        TileBase tile = tilemap.GetTile(gridPosition);
        Debug.Log("mouse in position = " + gridPosition + " is " + tile);
        return tile;
    }

    public tileData getTileData(TileBase tileBase)
    {
        return dataFromTiles[tileBase];
    }
}
