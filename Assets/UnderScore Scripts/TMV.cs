using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TMV : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTilemap;
    [SerializeField]
    private TileBase FloorTile, wallTop;


    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTilemap, FloorTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }

    internal void PaintSingleBasicWall(Vector2Int position)
    {
        PaintSingleTile(wallTilemap, wallTop, position);
    }
}
