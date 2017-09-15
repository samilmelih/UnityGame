using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyPanelController : MonoBehaviour
{
	// FIXME: We have this array in here and also EnemyController. Maybe we'll need it somewhere else too.
	// When we talk about gameplay, we need to look at this array.
	public Transform[] spawnPos;

	Dictionary<Character, GameObject> enemyPanelMap;

	Transform enemyPanels;

	World world;

	// Use this for initialization
	void Start ()
	{
		world = WorldController.Instance.world;

		enemyPanelMap = new Dictionary<Character, GameObject>();

		enemyPanels = GameObject.FindObjectOfType<Canvas>().transform.Find("EnemyPanels");

		world.RegisterOnEnemyChangedCallback(OnEnemyChanged);
		world.RegisterOnEnemyDestroyedCallback(OnEnemyDestroyed);

		CreateEnemyPanels();
	}

	void CreateEnemyPanels()
	{
		int numberOfEnemy = 0;

		foreach (Character enemy in world.enemies)
		{
			GameObject enemy_panel_prefab = Resources.Load<GameObject>("Prefabs/EnemyPanel");

			GameObject enemy_panel_go = Instantiate<GameObject>(enemy_panel_prefab, enemyPanels, false);

			enemy_panel_go.name = "Enemy_Panel_" + (numberOfEnemy + 1);
			enemy_panel_go.transform.position = Camera.main.WorldToScreenPoint(spawnPos[numberOfEnemy].position);

			enemyPanelMap.Add(enemy, enemy_panel_go);

			numberOfEnemy++;
		}
	}

	void OnEnemyChanged(Character enemy)
	{
		// Enemy is dead. Don't update.
		// We need this because Update is more frequently called then FixedUpdate.
		// There is no order between them. Enemy could be die anytime.
		if(enemy.isAlive == false)
			return;

		EnemyController enemyController = EnemyController.Instance;
		
		Transform enemy_panel_trans = enemyPanelMap[enemy].transform;
		Transform enemy_trans       = enemyController.enemyGOMap[enemy].transform;
		Vector3   position          = enemy_trans.Find("PanelPosition").position;

		enemy_panel_trans.position = Camera.main.WorldToScreenPoint(position);

		Transform healthBar   = enemy_panel_trans.Find("HealthBar");
		Transform filler      = healthBar.Find("Filler");
		Image     fillerImage = filler.GetComponent<Image>();

		// FIXME: It won't work when enemy shot. It'll work when enemy's moving.
		// In order to solve this, there is two options that I can see.
		// 1) Make another callback for health bar so we don't need unnecessary updates when enemy's moving.
		// 2) Use this callback but make call to this method (using the method in world) when enemy is shot.
		//    (We still have unnecessary updates in this option.)
		fillerImage.fillAmount = enemy.health / 100f;
	}

	void OnEnemyDestroyed(Character enemy)
	{
		GameObject enemyPanelGO = enemyPanelMap[enemy];

		enemyPanelMap.Remove(enemy);
		Destroy(enemyPanelGO);
	}
}
