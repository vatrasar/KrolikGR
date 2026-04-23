---
trigger: always_on
---

# reactive UI

## ReactiveUI Source Generators (Fody/Generation)

Direct implementation of `INotifyPropertyChanged`, manual `RaiseAndSetIfChanged`, or manual `ReactiveCommand` instantiation is strictly forbidden.

- **Property Declaration:** Use the `[Reactive]` attribute on private fields.

- **ReadOnly Properties (OAPH):** Use the `[ObservableAsProperty]` attribute.

- **Commands:** Use the `[ReactiveCommand]` attribute on private methods. This automatically generates a `ReactiveCommand` property with the appropriate name

Correct Pattern:

```csharp
//...
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

//...

public partial class ExampleViewModel : ViewModelBase
{
    [Reactive]
    private string _firstName = string.Empty;

    [ObservableAsProperty]
    private string? _fullName;

    // ✅ The generator creates "public IReactiveCommand SaveCommand"
    [ReactiveCommand]
    private async Task Save()
    {
        // Business logic for McDonald's Roster
        await Task.Delay(100); 
    }

    public ExampleViewModel()
    {
        this.WhenAnyValue(x => x.FirstName)
            .Select(name => $"User: {name}")
            .ToProperty(this, x => x.FullName);
    }
}
```

