using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMap : MonoBehaviour {

	public GameObject hexPrefab;

	int mapTileWidth  = 20;
	int mapTileHeight = 15;
	float xOffSet = 0.882f;
	float zOffSet = 0.764f;
    

	void Start () {

		generateTiles ();

		generateEnemyUnits ();
	}

	private void generateTiles(){
		

		for (int x = 0; x < mapTileWidth; x++) {	
			for (int z = 0; z < mapTileHeight; z++) {

				float xPos = x * xOffSet;
				float zPos = z * zOffSet;

				if (z % 2 == 1) {
					xPos += xOffSet / 2;	
				}

				GameObject hex_obj = (GameObject)Instantiate(hexPrefab, new Vector3(xPos, 0, zPos), Quaternion.identity);

				//Setting global variables in Hex script
				hex_obj.GetComponent<Hex>().setHex(xPos, zPos, x, z);

				//Parenting this hex to map for clean hierarchy view
				hex_obj.transform.SetParent (this.transform);

				hex_obj.isStatic = true;
                hex_obj.name = x + "_" + z;

			}
		}
	}

	private void generateEnemyUnits(){
		
		string objectLoc  = "Prefabs/EnemyUnits/Goblin1/goblin";
		string matLoc     = "Prefabs/EnemyUnits/Goblin1/Materials/goblin";

		GameObject enemy_obj = Resources.Load(objectLoc, typeof(GameObject)) as GameObject;

		Material mat = Resources.Load(matLoc, typeof(Material)) as Material;

		enemy_obj.GetComponentInChildren<SkinnedMeshRenderer>().material = mat;
		enemy_obj.GetComponentInChildren<Transform> ().Rotate (new Vector3 (0, 80, 0));



		for (int x = 0; x < mapTileWidth; x++) {	
			for (int z = 0; z < mapTileHeight; z++) {

				float xPos = x * xOffSet;
				float zPos = z * zOffSet;

				if (z % 2 == 1) {
					xPos += xOffSet / 2;	
				}

			    if(Random.Range(1, 10) == 5)
				Instantiate (enemy_obj, new Vector3(xPos, 0, zPos), Quaternion.identity);

			}
		}


	}
		
}
