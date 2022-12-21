using Infrastructure.Identity.Models.Authentication;

namespace Infrastructure.Identity.Services;

public interface ITokenService
{
    /// <summary>
    ///     Validate the credentials entered when logging in.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="ipAddress"></param>
    /// <returns></returns>
    Task<TokenResponse> Authenticate(TokenRequest request, string ipAddress);
} 