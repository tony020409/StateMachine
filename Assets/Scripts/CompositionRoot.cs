using UnityEngine;

public class CompositionRoot : MonoBehaviour {
    [SerializeField]
    private ScreenFadingEffect fadingEffect;

    private AsyncProcessor processor;
    private StateMachine stateMachine;

    private void Awake() {
        processor = new AsyncProcessor();
        stateMachine = new StateMachine( processor, fadingEffect );

        // This line is intentionally added for creating all static state. It will be removed if using DI framework.
        StateRepository stateRepository
            = new StateRepository( new NullState(), new TestOneState( stateMachine ), new TestTwoState( stateMachine ) );
    }

    private void Start() {
        stateMachine.Initialize();
    }

    private void Update() {
        stateMachine.Tick();
        processor.Tick();
    }
}