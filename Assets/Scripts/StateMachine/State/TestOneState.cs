using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TestOneState : State {
    private StateMachine stateMachine;

    public TestOneState( StateMachine stateMachine ) {
        this.stateMachine = stateMachine;
    }

    public override IEnumerator SetUp() {
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync( "TestScene1", LoadSceneMode.Additive );
        yield return asyncOp;
    }

    public override void Enter() {
        Debug.Log( "Enter TestOneState" );
    }

    public override void Update() {
        if ( Input.GetKeyDown( KeyCode.Space ) ) {
            stateMachine.ChangeState( StateRepository.TEST_TWO_STATE );
        }
    }

    public override void Exit() {
        Debug.Log( "Exit TestOneState" );
    }

    public override void Cleanup() {
        if ( SceneManager.UnloadScene( "TestScene1" ) == false ) {
            Debug.LogWarning( "Unload TestScene1 failed." );
        }
    }
}