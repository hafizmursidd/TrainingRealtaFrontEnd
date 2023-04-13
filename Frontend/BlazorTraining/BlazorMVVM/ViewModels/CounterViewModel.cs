namespace BlazorMVVM.ViewModels
{
    public class CounterViewModel
    {
        public int currentCount = 0;

        public void IncrementCount()
        {
            currentCount++;
        }
    }
}
