using UnityEngine;

public class CompositionRoot : MonoBehaviour {
    [SerializeField]
    private ScreenFadingEffect fadingEffect;

    private AsyncProcessor processor;
    private StateMachine stateMachine;

    private void Awake() {
        processor = new AsyncProcessor();
        stateMachine = new StateMachine( processor, fadingEffect );
    }

    private void Start() {
        stateMachine.Initialize();
    }

    private void Update() {
        stateMachine.Tick();
        processor.Tick();
    }
}