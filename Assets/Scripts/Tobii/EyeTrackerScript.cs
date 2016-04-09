using UnityEngine;
using System.Collections;
using Tobii.EyeX.Framework;

[RequireComponent (typeof(UserPresenceComponent))]
public class EyeTrackerScript : MonoBehaviour {
    public GazePointDataMode gazePointMode = GazePointDataMode.LightlyFiltered;

    private EyeXHost _eyeXHost;
    private IEyeXDataProvider<EyeXGazePoint> _gazePointProvider;
    private UserPresenceComponent userPresenceComponent;
    private Vector2 screenPoint;

    // Use this for initialization
    void Awake () {
        _eyeXHost = EyeXHost.GetInstance();
        _gazePointProvider = _eyeXHost.GetGazePointDataProvider(gazePointMode);
        userPresenceComponent = GetComponent<UserPresenceComponent>();
    }

    public void OnEnable()
    {
        _gazePointProvider.Start();
    }

    public void OnDisable()
    {
        _gazePointProvider.Stop();
    }

    // Update is called once per frame
    void Update () {
        var gazePoint = _gazePointProvider.Last;
        screenPoint = gazePoint.Screen;
    }

    public bool getEyePresence()
    {
        return userPresenceComponent.IsUserPresent;
    }

    public Vector2 getScreenPoint()
    {
        return screenPoint;
    }
}
