using System.Security.Claims;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using BinaryWorks.CleanArchitectureTemplate.Application.Interfaces;

namespace BinaryWorks.CleanArchitectureTemplate.Infrastructure
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IApplicationDbContext _context;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, AuthenticationStateProvider authenticationStateProvider, IApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _authenticationStateProvider = authenticationStateProvider;
            _context = context;
        }

        public async Task<string?> GetUserPicture()
        {
            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authenticationState.User;
            return user.FindFirstValue("picture");
        }

        private ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public Guid ApplicationUserId => Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "https://ads-sentry.com/applicationUserId")?.Value ?? string.Empty);
        public string? Username => _context.ApplicationUsers.Find(ApplicationUserId)?.Email;
        public string? Email => _context.ApplicationUsers.Find(ApplicationUserId)?.Email;
        public string? Name => string.Concat(FirstName, " ", LastName).Trim();
        public string? FirstName => _context.ApplicationUsers.Find(ApplicationUserId)?.FirstName;
        public string? LastName => _context.ApplicationUsers.Find(ApplicationUserId)?.LastName;
        public string? Sid => User.Claims.FirstOrDefault(c => c.Type == "sid")?.Value;
        public string? Picture => GetUserPicture().Result; // Note: This is blocking, you should consider making the property async or use a different approach.

        public Guid AccountId
        {
            get
            {
                var applicationUserId = User.Claims.FirstOrDefault(c => c.Type == "https://ads-sentry.com/applicationUserId")?.Value;

                if (applicationUserId is null)
                {
                    throw new ApplicationException("User Id is null");
                }

                var accountId = _context.ApplicationUsers.SingleOrDefault(u => u.Id == Guid.Parse(applicationUserId))?.AccountId;

                if (accountId is null)
                {
                    throw new ApplicationException("Account Id is null");
                }

                return (Guid)accountId;
            }
        }
    }
}