namespace State {
    public interface INextProvider<TData> {
        void Next<T>() where T : AState<TData>, new();
    }
}