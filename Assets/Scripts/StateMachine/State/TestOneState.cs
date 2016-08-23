using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TestOneState : State {
    public override IEnumerator SetUp() {
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync( "TestScene1", LoadSceneMode.Additive );
        yield return asyncOp;
    }

    public override void Enter( StateControl stateControl ) {
        Debug.Log( "Enter TestOneState" );
    }

    public override State Update( StateControl stateControl ) {
        if ( Input.GetKeyDown( KeyCode.Space ) ) {
            return StateRepository.TEST_TWO_STATE;
        }

        return null;
    }

    public override void Exit( StateControl stateControl ) {
        Debug.Log( "Exit TestOneState" );
    }

    public override void Cleanup() {
        if ( SceneManager.UnloadScene( "TestScene1" ) == false ) {
            Debug.LogWarning( "Unload TestScene1 failed." );
        }
    }
}