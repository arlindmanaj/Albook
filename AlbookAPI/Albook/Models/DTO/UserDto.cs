public class UserDTO
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
}

public class ChangeRoleRequest
{
    public string Role { get; set; }
    public string Username { get; set; }
}
