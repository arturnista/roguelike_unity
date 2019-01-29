using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName="Maps/Create Modular")]
public class MapModular : Map {

    public GameObject[] RoomsPrefabs;

    public override void Create(Transform parent)
    {
        base.Create(parent);
        
        Vector3 center = Vector3.zero;

        for (int x = 0; x < 2; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                
                GameObject prefab = RoomsPrefabs[Random.Range(0, RoomsPrefabs.Length)];
                Vector3 roomPosition = new Vector3(
                    center.x + ( Random.Range(30, 50) * x ) + 10,
                    center.x + ( Random.Range(30, 50) * y ) + 10,
                    0f
                );
                Instantiate(prefab, roomPosition, Quaternion.identity).transform.parent = parent;
            }
        }
        
    }

}