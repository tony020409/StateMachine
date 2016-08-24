using System.Collections;

public class StateMachine : StateControl {
    private static readonly float TRANSITION_TIME = 1f;

    private readonly AsyncProcessor processor;
    private readonly StateTransit stateTransit;

    private State state;
    private bool isTransitting = false;

    public StateMachine( AsyncProcessor processor, StateTransit stateTransit ) {
        this.processor = processor;
        this.stateTransit = stateTransit;
    }

    public void Initialize() {
        state = StateRepository.NULL_STATE;
        ChangeState( StateRepository.TEST_ONE_STATE );
    }

    public void Tick() {
        if ( isTransitting == false ) {
            state.Update();
        }
    }

    public void ChangeState( State nextState ) {
        processor.Process( Transit( nextState ) );
    }

    private IEnumerator Transit( State nextState ) {
        isTransitting = true;

        yield return stateTransit.FadeIn( TRANSITION_TIME );

        state.Exit();
        state.Cleanup();
        state = nextState;
        yield return state.SetUp();
        state.Enter();

        yield return stateTransit.FadeOut( TRANSITION_TIME );

        isTransitting = false;
    }
}