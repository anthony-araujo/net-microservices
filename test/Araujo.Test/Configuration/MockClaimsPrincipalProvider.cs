using System.Security.Claims;

namespace araujo.Test.Configuration;

public class MockClaimsPrincipalProvider
{
    public MockClaimsPrincipalProvider(ClaimsPrincipal user)
    {
        User = user;
    }

    public ClaimsPrincipal User { get; }
}
