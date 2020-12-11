using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int buttonPressed = 0;
	
    public GameObject Zombies;

    // Start is called before the first frame update
    void Start()
    {
         // Instantiate zombies on start of game
        for (int i = 0; i < 20; i++)
        {
			float x = Random.Range(Terrain.activeTerrain.transform.position.x, Terrain.activeTerrain.transform.position.x + Terrain.activeTerrain.terrainData.size.x);
			float z = Random.Range(Terrain.activeTerrain.transform.position.z, Terrain.activeTerrain.transform.position.z + Terrain.activeTerrain.terrainData.size.z);
			Vector3 pos = new Vector3(x, 500, z);
			float y = Terrain.activeTerrain.SampleHeight(pos);
			pos.y = y;
			GameObject Zombie = Instantiate(Zombies, pos, Quaternion.identity);
			
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
    public void StartGame()
	{
		buttonPressed++;

		if (buttonPressed > 0)
        {
			// Load level
			SceneManager.LoadScene("final");
		}
	}
}
