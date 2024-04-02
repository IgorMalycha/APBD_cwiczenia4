namespace LegacyApp.Tests;

public class UserServiceTest
{
    [Fact]
    public void AddUsersReturnsFalseFirstNameIsEmpty()
    {
        
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser(null, "Kowalski",
            "kowalski@kowalski.pl", DateTime.Parse("2000-01-01"),
            1);
        

        //Assert
        Assert.False(result);


    }
    
    [Fact]
    public void AddUsersThrowsArgumentExceptionClientDoesNotExists()
    {
        
        //Arrange
        var userService = new UserService();
        
        //Act
        Action action = () => userService.AddUser("Jan", "Kowalski",
            "kowalski@kowalski.pl", DateTime.Parse("2000-01-01"),
            100);
        
        //Assert
        Assert.Throws<ArgumentException>(action);

    }
}