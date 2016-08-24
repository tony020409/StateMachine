using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TestTwoState : State {
    private StateMachine stateMachine;

    public TestTwoState( StateMachine stateMachine ) {
        this.stateMachine = stateMachine;
    }

    public override IEnumerator SetUp() {
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync( "TestScene2", LoadSceneMode.Additive );
        yield return asyncOp;
    }

    public override void Enter() {
        Debug.Log( "Enter TestTwoState" );   
    }

    public override void Update() {
        if ( Input.GetKeyDown( KeyCode.Space ) ) {
            stateMachine.ChangeState( StateRepository.TEST_ONE_STATE );
        }
    }

    public override void Exit() {
        Debug.Log( "Exit TestTwoState" );
    }

    public override void Cleanup() {
        if ( SceneManager.UnloadScene( "TestScene2" ) == false ) {
            Debug.LogWarning( "Unload TestScene2 failed." );
        }
    }
}