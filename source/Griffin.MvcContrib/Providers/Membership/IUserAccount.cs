using System;

namespace Griffin.MvcContrib.Providers.Membership
{
    /// <summary>
    /// Account information for a user 
    /// </summary>
    public interface IUserAccount
    {
        /// <summary>
        /// Gets or sets application that the user belongs to
        /// </summary>
        string ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets email address
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets password question that must be answered to reset password
        /// </summary>
        /// <remarks>
        /// Controlled by the <see cref="IPasswordPolicy.IsPasswordQuestionRequired"/> property.
        /// </remarks>
        string PasswordQuestion { get; set; }

        /// <summary>
        /// Gets or sets answer for the <see cref="PasswordQuestion"/>.
        /// </summary>
        string PasswordAnswer { get; set; }

        /// <summary>
        /// Gets or sets a comment about the user.
        /// </summary>
        string Comment { get; set; }

        /// <summary>
        /// Gets or sets date/time when the user logged in last.
        /// </summary>
        DateTime LastLoginAt { get; set; }

        /// <summary>
        /// Gets or sets whether a new user have been approved and may login.
        /// </summary>
        bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets when the password were changed last time.
        /// </summary>
        DateTime LastPasswordChangeAt { get; set; }

        /// <summary>
        /// Gets or sets if the account has been locked (the user may not login)
        /// </summary>
        bool IsLockedOut { get; set; }

        /// <summary>
        /// Gets or sets if the user is online
        /// </summary>
        /// <remarks>
        /// Caluclated with the help of <see cref="LastActivityAt"/>.
        /// </remarks>
        bool IsOnline { get; }

        /// <summary>
        /// Gets or sets when the user was locked out.
        /// </summary>
        DateTime LastLockedOutAt { get; set; }

        /// <summary>
        /// Gets or sets when the user entered an incorrect password for the first time
        /// </summary>
        /// <value>
        /// DateTime.MinValue if the user has not entered an incorrect password (or succeded to login again).
        /// </value>
        DateTime FailedPasswordWindowStartedAt { get; set; }

        /// <summary>
        /// Gets or sets number of login attempts since <see cref="FailedPasswordWindowStartedAt"/>.
        /// </summary>
        int FailedPasswordWindowAttemptCount { get; set; }

        /// <summary>
        /// Gets or sets when the user answered the password question incorrect for the first time.
        /// </summary>
        /// <value>
        /// DateTime.MinValue if the user has not entered an incorrect answer (or succeded to login again).
        /// </value>
        DateTime FailedPasswordAnswerWindowStartedAt { get; set; }

        /// <summary>
        /// Gets or sets number of times that the user have answered the password question incorrectly since <see cref="FailedPasswordAnswerWindowAttemptCount"/>
        /// </summary>
        int FailedPasswordAnswerWindowAttemptCount { get; set; }

        /// <summary>
        /// Gets or sets when the user account was created.
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets date/time when the user did something on the site
        /// </summary>
        DateTime LastActivityAt { get; set; }

        /// <summary>
        /// Gets or sets ID identifying the user
        /// </summary>
        /// <remarks>
        /// Should be an id in your system (for instance i your database)
        /// </remarks>
        object Id { get; set; }

        string UserName { get; set; }
        string Password { get; set; }
        string PasswordSalt { get; set; }
    }
}