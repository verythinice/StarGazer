using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    public GameObject graphic;
    public int depth;
    public int width;

    public float wiggleBase;
    public float wiggleVariation;

	// Use this for initialization
	void Start()
    {
        width = Mathf.RoundToInt(width * PlayerPrefs.GetFloat("MichaelBay", 1.0f));
        GameObject spawnedGraphic = (GameObject)GameObject.Instantiate(graphic, transform.position, Quaternion.identity);
        Vector3 direction = new Vector3(0, 0, 0);
        direction.x = Random.Range(-1.0f, 1.0f);
        direction.y = Random.Range(-1.0f, 1.0f);
        direction.Normalize();
        float speed = wiggleBase + Random.Range(-wiggleVariation, wiggleVariation);
        Drift drift = spawnedGraphic.AddComponent<Drift>();
        drift.direction = direction;
        drift.speed = speed;
	    if (depth == 0)
        {
            Destroy(gameObject);
            return;
        }

        for (int i = 0; i < width; ++i)
        {
            Vector3 jiggle = new Vector3(0, 0, 0);
            direction.x = Random.Range(-1.0f, 1.0f);
            direction.y = Random.Range(-1.0f, 1.0f);
            jiggle.Normalize();
            jiggle = jiggle * (wiggleBase + Random.Range(-wiggleVariation, wiggleVariation));
            GameObject spawnedObject = (GameObject) GameObject.Instantiate(gameObject, jiggle + transform.position, Quaternion.identity);
            spawnedObject.GetComponent<Explosion>().depth -= 1;
        }

        Destroy(gameObject);
	}
}
