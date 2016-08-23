using System.Collections;

public class StateMachine : StateControl {
    private static readonly float TRANSITION_TIME = 1f;

    private readonly AsyncProcessor processor;
    private readonly StateTransit stateTransit;

    private State state = StateRepository.NULL_STATE;
    private bool isTransitting = false;

    public StateMachine( AsyncProcessor processor, StateTransit stateTransit ) {
        this.processor = processor;
        this.stateTransit = stateTransit;
    }

    public void Initialize() {
        processor.Process( Transit( StateRepository.TEST_ONE_STATE ) );
    }

    public void Tick() {
        if ( isTransitting == false ) {
            UpdateState();
        }
    }

    private void UpdateState() {
        State nextState = state.Update( this );
        if ( nextState != null ) {
            processor.Process( Transit( nextState ) );
        }
    }

    private IEnumerator Transit( State nextState ) {
        isTransitting = true;

        yield return stateTransit.FadeIn( TRANSITION_TIME );

        state.Exit( this );
        state.Cleanup();
        state = nextState;
        yield return state.SetUp();
        state.Enter( this );

        yield return stateTransit.FadeOut( TRANSITION_TIME );

        isTransitting = false;
    }
}