﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMail.Infrastructure.Database.Scripts {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Sql {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Sql() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WebMail.Infrastructure.Database.Scripts.Sql", typeof(Sql).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT mbx.mbx_id AS Id
        ///	, mbx.mbx_domain_name AS DomainName
        ///	, mbx.mbx_imap_address AS ImapAddress
        ///	, mbx.mbx_imap_port AS ImapPort
        ///	, mbx.mbx_smtp_address AS SmtpAddress
        ///	, mbx.mbx_smtp_port AS SmtpPort
        ///	, mbx.mbx_smtp_ssl AS SmtpSsl
        ///	, mbx.mbx_imap_ssl AS ImapSsl
        ///FROM mailboxes mbx
        ///WHERE mbx.mbx_domain_name = @DomainName.
        /// </summary>
        public static string FindMailboxByName {
            get {
                return ResourceManager.GetString("FindMailboxByName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT usr.usr_id AS Id
        ///	, usr.usr_name AS UserName
        ///	, usr.usr_admin AS IsAdmin
        ///	, usr.mbx_id AS MailboxId
        ///FROM users usr
        ///WHERE usr.usr_name = @UserName AND usr.mbx_id = @MailboxId
        ///.
        /// </summary>
        public static string FindUserByName {
            get {
                return ResourceManager.GetString("FindUserByName", resourceCulture);
            }
        }
    }
}
