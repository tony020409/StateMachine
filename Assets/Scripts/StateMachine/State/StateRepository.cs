// The reason why this class looks like as below is just because I program with DI framework.
// Assume that I'm using a DI framework,
// I'll just inject DI container into StateRepository and instantiate all state in the constructor.
public class StateRepository {
    public static State NULL_STATE;
    public static State TEST_ONE_STATE;
    public static State TEST_TWO_STATE;

    public StateRepository( NullState nullState, TestOneState testOneState, TestTwoState testTwoState ) {
        NULL_STATE = nullState;
        TEST_ONE_STATE = testOneState;
        TEST_TWO_STATE = testTwoState;
    }
}