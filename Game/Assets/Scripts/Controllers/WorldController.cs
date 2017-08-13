using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

	public static WorldController Instance;

	public World world;

	// Use this for initialization
	void Awake()
	{
        
        if(Instance==null)
		{
			Instance = this;
		}

        if(world==null)
			world = new World();

		// FIXME: Kamera karakteri ortalamıyor. Burada mı düzeltilmeli emin değilim.

       /// LoadCharacter();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadCharacter()
    {

       //Karakterimizi Prefabs klasöründen yklüyorum bu sayede sadece burada bir kaç
        //satırda değişiklik yaparak karakteri değiştirebilirm ve yüklemek istediğim nesneler
        //için genelleştirilmiş bir kod olabilir
        GameObject go=Resources.Load<GameObject>("Prefabs/Character");


        go.name="Character";
        go.transform.position = Vector3.zero;
        go.transform.rotation = Quaternion.identity;

        Instantiate(go,GameObject.FindObjectOfType<CharacterController>().transform);

        Camera.main.transform.SetParent(go.transform, false);//FIXME : burası hardcoded bir sistem oldu
                                                        // ama bu bizim işişmizi görür....
    }
}
