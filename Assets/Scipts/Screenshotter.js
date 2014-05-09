/*#pragma strict

import System.IO;

function Start () {

}

function Update () {
	
}

function SaveTextureToFile( texture: Texture2D,fileName){
	var bytes=texture.EncodeToPNG();
	var file = new File.Open(Application.dataPath + "/" + fileName,FileMode.Create);
	var binary= new BinaryWriter(file);
	
	binary.Write(bytes);
	
	file.Close();
}*/