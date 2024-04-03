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

    [Fact]
    public void AddUsersReturnsFalseSecondNameIsEmpty()
    {
        var userService = new UserService();
        
        var result = userService.AddUser("Jan", null,
            "kowalski@kowalski.pl", DateTime.Parse("2000-01-01"),
            1);
        
        
        Assert.False(result);
    }
    
    [Fact]
    public void AddUsersReturnsFalseEmailDoentContainsPeriodAndAtSign()
    {
        var userService = new UserService();
        
        var result = userService.AddUser("Jan", "Kowalski",
            "kowalskikowalskipl", DateTime.Parse("2000-01-01"),
            1);
        
        Assert.False(result);
        
    }
    
    [Fact]
    public void AddUsersReturnsFalseAgeUnder21()
    {
        var userService = new UserService();
        
        var result = userService.AddUser("Jan", "Kowalski",
            "kowalski@kowalski.pl", DateTime.Parse("2004-01-01"),
            1);
        
        Assert.False(result);
        
    }
    [Fact]
    public void AddUsersReturnsTrueUsersTypeVeryImportant()
    {
        var userService = new UserService();
        
        var result = userService.AddUser("Jan", "Malewski",
            "malewski@gmail.pl", DateTime.Parse("2000-01-01"),
            2);
        
        Assert.True(result);
        
    }
    
    [Fact]
    public void AddUsersReturnsTrueUsersTypeImportant()
    {
        var userService = new UserService();
        
        var result = userService.AddUser("Jan", "Smith",
            "smith@gmail.pl", DateTime.Parse("2000-01-01"),
            3);
        
        Assert.True(result);
        
    }
    
    [Fact]
    public void AddUsersReturnsFalseUsersHasCreditLimitAndlimitUnder500()
    {
        var userService = new UserService();
        var result = userService.AddUser("Jan", "Kowalski",
            "kowalski@wp.pl", DateTime.Parse("2000-01-01"),
            1);
        
        Assert.False(result);
        
    }
    
    [Fact]
    public void AddUsersThrowsArgumentExceptionNoClientWithThisLastName()
    {
        
        var userService = new UserService();
        
        Action action = () => userService.AddUser("Jan", "Kowalskiii",
            "kowalski@kowalski.pl", DateTime.Parse("2000-01-01"),
            1);

        Assert.Throws<ArgumentException>(action);

    }
    
}