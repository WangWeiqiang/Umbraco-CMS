﻿using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Runtime.Serialization;

namespace Umbraco.Web.Security
{
    /// <summary>
    /// Options used to configure back office external login providers
    /// </summary>
    public class BackOfficeExternalLoginProviderOptions
    {
        /// <summary>
        /// When specified this will be called to retrieve the <see cref="AuthenticationProperties"/> used during the authentication Challenge response.
        /// </summary>
        /// <remarks>
        /// For example, when trying to implement an Azure AD B2C provider or other OAuth provider that requires a customized Challenge Result in order to work then
        /// this must be used.
        /// See: http://issues.umbraco.org/issue/U4-7353
        /// </remarks>
        [IgnoreDataMember]
        public Func<IOwinContext, AuthenticationProperties> OnChallenge { get; set; }

        /// <summary>
        /// Options used to control how users can be auto-linked/created/updated based on the external login provider
        /// </summary>
        [IgnoreDataMember] // we are ignoring this one from serialization for backwards compat since these options are manually incuded in the response separately
        public ExternalSignInAutoLinkOptions AutoLinkOptions { get; set; }

        /// <summary>
        /// When set to true will disable all local user login functionality
        /// </summary>
        public bool DenyLocalLogin { get; set; }

        /// <summary>
        /// If specified and <see cref="DenyLocalLogin"/> is true then the user invite button in the back office will link through to this custom URL
        /// </summary>
        public string CustomUserInviteLink { get; set; }

        /// <summary>
        /// When specified this will automatically redirect to the OAuth login provider instead of prompting the user to click on the OAuth button first.
        /// </summary>
        /// <remarks>
        /// This is generally used in conjunction with <see cref="DenyLocalLogin"/>. If more than one OAuth provider specifies this, the last registered
        /// provider's redirect settings will win.
        /// </remarks>
        public bool AutoRedirectLoginToExternalProvider { get; set; }
    }
}