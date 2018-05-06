using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEmitter : MonoBehaviour {

    [SerializeField] GameObject enemy;
    [SerializeField] public int remaining = 1;
    [SerializeField] float rate = 1f;
    [SerializeField] int scoreValue = 1;
    [SerializeField] float delay = 0f;
	[SerializeField] float range = 35f;
	[SerializeField] int hp = 2;

	void Start () {
		StartCoroutine(EmitEnemies());
	}
	
    IEnumerator EmitEnemies() {
        yield return new WaitForSeconds(delay);

        while (remaining > 0) {
            var enemies = FindObjectsOfType<Enemy>();

            if (enemies.Length < 30) {
                Vector3 randoSpot = new Vector3(Random.Range(-Mathf.Abs(range), range), 2f, Random.Range(-Mathf.Abs(range), range));
                GameObject enemyInstance = Instantiate(enemy, randoSpot, Quaternion.identity);
                Enemy enemyComponent = enemyInstance.GetComponent<Enemy>();
                enemyComponent.hp = hp;

                remaining--;
            }

            yield return new WaitForSeconds(rate);
        }
    }
}