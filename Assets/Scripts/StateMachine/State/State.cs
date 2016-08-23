using System.Collections;

public abstract class State {
    public virtual IEnumerator SetUp() {
        yield break;
    }

    public virtual void Enter( StateControl stateControl ) {

    }

    public virtual State Update( StateControl stateControl ) {
        return null;
    }

    public virtual void Exit( StateControl stateControl ) {

    }

    public virtual void Cleanup() {

    }
}