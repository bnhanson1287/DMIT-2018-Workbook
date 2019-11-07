### Queries
```csharp
public class PickerSelection
{
    public int PickerID {get;set;}
    public string PickerName 
    {
        get
        {
            string result = $"{FirstName} {LastName}"

            return result;
        }
    }
}
```

