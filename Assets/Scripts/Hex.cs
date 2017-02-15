using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour {

	public float xPos;
	public float zPos;
	public int xCount;
	public int zCount;

	private string defaultMaterialLoc  = "Prefabs/Hex/Materials/BlackHexBoarder";
	private string selectedMaterialLoc = "Prefabs/Hex/Materials/RedHexBoarder";

	public void setHex(float xPos, float zPos,  int xCount, int zCount){
		this.xPos = xPos;
		this.zPos = zPos;
		this.xCount = xCount;
		this.zCount = zCount;
		this.tag = "Tile";
		setName();
		setMaterial();

	}
	public void setName(){
		this.name = "Hex_"+xCount+"_"+zCount;
	}

	public void setMaterial(){
		setDefaultMatterial();
	}

	public void selectTile(){
		unselectSelectedTiles ();
		this.tag = "SelectedTile";
		setSelectedMaterial ();
	}
	private void setSelectedMaterial(){
		Material mat = Resources.Load(selectedMaterialLoc, typeof(Material)) as Material;
		this.GetComponentInChildren<MeshRenderer>().material = mat;
	}

	public void setDefaultMatterial(){
		Material mat = Resources.Load(defaultMaterialLoc, typeof(Material)) as Material;
		this.GetComponentInChildren<MeshRenderer>().material = mat;
	}

	public void unselectSelectedTiles(){

		GameObject[] selectedTiles = GameObject.FindGameObjectsWithTag ("SelectedTile");

		for (int i = 0; i < selectedTiles.Length; i++) {
			selectedTiles [i].GetComponent<Hex> ().setDefaultMatterial ();
		}

	}
}
