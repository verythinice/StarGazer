using UnityEngine;
using System.Collections;

public class HealthBarScript : Base {

    public RectTransform healthBarTransform;
    float width, remainingRatio;
    Vector3 originalPosition;

	// Use this for initialization
	public override void Start () {
        base.Start();

        width = healthBarTransform.rect.width;
        originalPosition = healthBarTransform.localPosition;
	}
	
	// Update is called once per frame
    public override void Update()
    {
        base.Update();

        remainingRatio = Mathf.Clamp01(1 - player.health / player.maxHealth);
        healthBarTransform.localPosition = new Vector3(
             remainingRatio * width + originalPosition.x,
            originalPosition.y, originalPosition.z);
	}
}
