using System.Collections;

public abstract class State {
    public virtual IEnumerator SetUp() {
        yield break;
    }

    public virtual void Enter() {

    }

    public virtual void Update() {

    }

    public virtual void Exit() {

    }

    public virtual void Cleanup() {

    }
}