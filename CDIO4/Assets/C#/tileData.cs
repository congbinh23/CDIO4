using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Data/Tile Data")]
public class tileData : ScriptableObject
{
    public List<TileBase> tiles;

    public bool plowable; 
}
