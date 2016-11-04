using UnityEngine;
using System.Collections;

public class Streetmaker : MonoBehaviour {

	int stepCount = 0;
	public Transform streetMakerPrefab;
	public Transform buildingPrefab;

	void start () {
	}

	// Update is called once per frame
	void Update () {

		transform.position = transform.position + transform.forward * Random.Range(-1f, 5f);


		if (stepCount <=60) {
			float randomNumber = Random.Range (0f, 100f);
			if (randomNumber < 50f) {
				Transform leftBuilding = (Transform) Instantiate(buildingPrefab, 
										  transform.position - transform.right * 2f, 
										  transform.rotation
				                         );
				leftBuilding.transform.localScale = new Vector3 (1f, Random.Range (1f, 10f), 1f);
				leftBuilding.GetComponent<Renderer> ().material.color = Random.ColorHSV();
			
				Transform rightBuilding = (Transform) Instantiate(buildingPrefab, 
										  transform.position + transform.right * 3f, 
										  transform.rotation
				                          );
				rightBuilding.transform.localScale = new Vector3 (1f, Random.Range (1f, 5f), 1f);

				rightBuilding.GetComponent<Renderer> ().material.color = Random.ColorHSV();

			} else {
				float anotherRandom = Random.Range (0f, 100f);
				if (anotherRandom < 50f) {
					Transform.Instantiate (streetMakerPrefab, 
						transform.position = new Vector3(Random.Range(1f, 30f), 0f, Random.Range(1f, 30f)),
						Quaternion.Euler (0, transform.eulerAngles.y -40, 0)
					);
				} else {
					Transform.Instantiate (streetMakerPrefab, 
						transform.position = new Vector3(Random.Range(-1f, -30f), 0f, Random.Range(-1f, -30f)),
						Quaternion.Euler (0, transform.eulerAngles.y + 40, 0)
					);
				}
			}
		
			stepCount++;
		}
	}

}