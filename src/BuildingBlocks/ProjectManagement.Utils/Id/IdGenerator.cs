namespace ProjectManagement.Utils.Id;

public class IdGenerator : IIdGenerator
{
    public string GenerateUniqueId()
    {
        return Guid.NewGuid().ToString();
    }
}