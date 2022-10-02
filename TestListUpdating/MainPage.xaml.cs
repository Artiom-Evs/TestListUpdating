using TestListUpdating.State;

namespace TestListUpdating;

public partial class MainPage : ContentPage
{
    private States _state;
    private int[] _someData;

	public MainPage()
	{
		InitializeComponent();
		this.BindingContext = this;

        SomeData = Enumerable.Range(0, 10).ToArray();
        State = States.Success;

        _ = Task.Run(ExecuteSomeWorkAsync);
    }

    public States State
    {
        get => _state;
        private set
        {
            if (_state != value)
            {
                _state = value;
                OnPropertyChanged();
            }
        }
    }
	public int[] SomeData
    {
        get => _someData;
        private set
        {
            if (_someData != value)
            {
                _someData = value;
                OnPropertyChanged();
            }
        }
    }

	private async Task ExecuteSomeWorkAsync()
	{
        await Task.Delay(2000);

        State = States.Loading;

        await Task.Delay(2000);

        Random rnd = new();
        var data = Enumerable.Range(0, 10).Select(n => rnd.Next(0, 10)).ToArray();

        SomeData = data;

        State = States.Success;
    }
}

