using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TestTwoState : State {
    public override IEnumerator SetUp() {
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync( "TestScene2", LoadSceneMode.Additive );
        yield return asyncOp;
    }

    public override void Enter( StateControl stateControl ) {
        Debug.Log( "Enter TestTwoState" );   
    }

    public override State Update( StateControl stateControl ) {
        if ( Input.GetKeyDown( KeyCode.Space ) ) {
            return StateRepository.TEST_ONE_STATE;
        }

        return null;
    }

    public override void Exit( StateControl stateControl ) {
        Debug.Log( "Exit TestTwoState" );
    }

    public override void Cleanup() {
        if ( SceneManager.UnloadScene( "TestScene2" ) == false ) {
            Debug.LogWarning( "Unload TestScene2 failed." );
        }
    }
}