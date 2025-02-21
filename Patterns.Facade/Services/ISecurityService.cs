namespace Patterns.Facade.Services;

public interface ISecurityService
{
    void AuthenticateUser();
    void LogOut();
}