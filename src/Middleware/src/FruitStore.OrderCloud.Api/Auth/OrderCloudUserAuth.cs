﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderCloud.Catalyst;
using OrderCloud.SDK;

namespace FruitStore.OrderCloud.Api
{
	/// <summary>
	/// Apply to controllers or actions to require that a valid OrderCloud access token is provided in the Authorization header.
	/// </summary>
	public class OrderCloudUserAuthAttribute : AuthorizeAttribute
	{
		public List<string> OrderCloudRoles => Roles?.Split(',')?.ToList() ?? new List<string> { };

		public OrderCloudUserAuthAttribute()
		{
			AuthenticationSchemes = "OrderCloudUser";
		}

		/// <param name="roles">Optional list of roles. If provided, user must have just one of them, otherwise authorization fails.</param>
		public OrderCloudUserAuthAttribute(params ApiRole[] roles)
		{
			AuthenticationSchemes = "OrderCloudUser";
			var rolesList = roles.ToList();
			rolesList.Add(ApiRole.FullAccess); 
			Roles = string.Join(",", rolesList);
		}

		/// <param name="roles">Optional list of roles. If provided, user must have just one of them, otherwise authorization fails.</param>
		public OrderCloudUserAuthAttribute(params string[] roles)
		{
			AuthenticationSchemes = "OrderCloudUser";
			var rolesList = roles.ToList();
			rolesList.Add("FullAccess");
			Roles = string.Join(",", rolesList);
		}
	}

	public class OrderCloudUserAuthHandler : AuthenticationHandler<OrderCloudUserAuthOptions>
	{
		private static RequestAuthenticationService _tokenProvider;

		public OrderCloudUserAuthHandler(
			IOptionsMonitor<OrderCloudUserAuthOptions> options,
			ILoggerFactory logger,
			UrlEncoder encoder,
			ISystemClock clock,
			RequestAuthenticationService tokenProvider
			)
			: base(options, logger, encoder, clock)
		{
			_tokenProvider = tokenProvider;
		}

		protected override async Task<AuthenticateResult> HandleAuthenticateAsync() {
			try {
				var requiredRoles = Context.GetRequiredOrderCloudRoles();
				var allowedUserTypes = Context.GetAllowedUserTypes();
				var token = await _tokenProvider.VerifyTokenAsync(Request, Options, requiredRoles, allowedUserTypes);
				var cid = new ClaimsIdentity("OcUser");
				cid.AddClaims(token.Roles.Select(r => new Claim(ClaimTypes.Role, r)));
				cid.AddClaim(new Claim("AccessToken", token.AccessToken));

				var ticket = new AuthenticationTicket(new ClaimsPrincipal(cid), "OcUser");
				return AuthenticateResult.Success(ticket);
			}
			catch (CatalystBaseException ex)
			{
				throw ex;
			}
			catch (OrderCloudException ex)
			{
				throw ex;
			}
			catch (Exception ex) {
				throw new UnAuthorizedException();
			}
		}
	}

	public class OrderCloudUserAuthOptions : AuthenticationSchemeOptions
	{
		public bool AnyClientIDCanAccess { get; set; } = false;
		public List<string> ValidClientIDs { get; set; } = new List<string>();

		/// <summary>
		/// Enforce that only tokens associated with specific OrderCloud client ID(s) are allowed to access endpoints marked with [OrderCloudUserAuth].
		/// </summary>
		public OrderCloudUserAuthOptions AddValidClientIDs(params string[] clientIDs)
		{
			ValidClientIDs.AddRange(clientIDs);
			return this;
		}

		public OrderCloudUserAuthOptions AllowAnyClientID()
		{
			AnyClientIDCanAccess = true;
			return this;
		}
	}
}
