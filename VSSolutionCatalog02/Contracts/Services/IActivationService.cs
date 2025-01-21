namespace VSSolutionCatalog02.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
