using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public abstract class CircularBarScript : Base {

    public Image circular;
    public float remainingRatio, maxLength;
    public bool invertFill;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        maxLength = circular.fillAmount;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        remainingRatio = Mathf.Clamp01(getCurrentAmount() / getMaxAmount());
        circular.fillAmount = maxLength * (invertFill ? 1 - remainingRatio : remainingRatio);
    }

    //  should override this in a new class to use
    abstract public float getCurrentAmount();

    //  should override this in a new class to use
    abstract public float getMaxAmount();

}
