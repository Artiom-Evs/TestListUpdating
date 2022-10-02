
namespace TestListUpdating.State;

[ContentProperty("Conditions")]
public class StateContainer : ContentView
{
    public List<StateCondition> Conditions { get; set; } = new();

    public static readonly BindableProperty StateProperty = 
        BindableProperty.Create(nameof(State), typeof(object), typeof(StateContainer), null, BindingMode.Default, null, StateChanged);

    private static void StateChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var parent = bindable as StateContainer;
        if (parent != null)
            parent.ChooseStateProperty(newValue);
    }

    public object State
    {
        get { return GetValue(StateProperty); }
        set { SetValue(StateProperty, value); }
    }

    private void ChooseStateProperty(object newValue)
    {
        if (Conditions == null && Conditions?.Count == 0) return;

        var stateCondition = Conditions
            .FirstOrDefault(condition =>
                condition.State != null &&
                condition.State.ToString().Equals(newValue.ToString()));

        if (stateCondition == null) return;

        Content = stateCondition.Content;
    }
}
