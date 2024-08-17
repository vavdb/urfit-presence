using Microsoft.AspNetCore.Identity;
using urfit_presence;
using urfit_presence.Data;

public class SubscriptionService
{
    // private readonly InformerApiClient _apiClient;
    private readonly UserManager<ApplicationUser> _userManager;

    // public SubscriptionService(InformerApiClient apiClient, UserManager<ApplicationUser> userManager)
    // {
    //     _apiClient = apiClient;
    // }

    // public async Task SyncSubscriptionsToUsers()
    // {
    //     try
    //     {
    //         var subscriptionResponses = await _apiClient.SubscriptionsAsync("", 1000, 0);
    //         foreach (var response in subscriptionResponses)
    //         {
    //
    //         }
    //     }
    //     catch (HttpRequestException e)
    //     {
    //         Console.WriteLine($"Error: {e.Message}");
    //     }
    // }
}