namespace LegacyApp.Tests;

public class UserServiceTest
{
    [Fact]
    public void AddUsersReturnsFalseFirstNameIsEmpty()
    {
        
        //Arrange
        var UserService = new UserService();
        
        //Act
        var result = UserService.AddUser(null, "Kowalski",
            "kowalski@kowalski.pl", DateTime.Parse("2000-01-01"),
            1);
        

        //Assert
        Assert.False(result);


    }
    
    [Fact]
    public void AddUsers_ThrowsArgumentExceptionClientDoesNotExists()
    {
        
        //Arrange
        var UserService = new UserService();
        
        //Act
        Action action = () => UserService.AddUser("Jan", "Kowalski",
            "kowalski@kowalski.pl", DateTime.Parse("2000-01-01"),
            100);
        
        //Assert
        Assert.Throws<ArgumentException>(action);

    }
}