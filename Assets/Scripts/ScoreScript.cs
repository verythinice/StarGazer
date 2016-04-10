using UnityEngine;
using System.Collections;

public class ScoreScript : Base {

    public bool isLogging;

    public static int score;

	public override void Start()
    {
        base.Start();

        score = 0;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        score += Random.Range(1, 5);
        if (isLogging)
        {
            Debug.Log(score);
        }
    }
}
