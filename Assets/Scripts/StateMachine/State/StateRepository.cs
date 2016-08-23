// Assume that I'm using a DI framework,
// I'll make it a non-static class and inject DI container and instantiate all state at the constructor.
// That's why this class looks like as below.
public static class StateRepository {
    private static State nullState;
    private static State testOneState;
    private static State testTwoState;

    static StateRepository() {
        nullState = new NullState();
        testOneState = new TestOneState();
        testTwoState = new TestTwoState();
    }

    public static State NULL_STATE {
        get { return nullState; }
    }

    public static State TEST_ONE_STATE {
        get { return testOneState; }
    }

    public static State TEST_TWO_STATE {
        get { return testTwoState; }
    }
}