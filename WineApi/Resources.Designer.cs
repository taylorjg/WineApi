﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WineApi {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WineApi.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A critical error was encountered. This is due to a bug in the service. Please notify wine.com ASAP to correct this issue..
        /// </summary>
        internal static string ReturnCodeCriticalError {
            get {
                return ResourceManager.GetString("ReturnCodeCriticalError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Access. Account does not have access to this service..
        /// </summary>
        internal static string ReturnCodeNoAccess {
            get {
                return ResourceManager.GetString("ReturnCodeNoAccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Everything worked, no problems..
        /// </summary>
        internal static string ReturnCodeSuccess {
            get {
                return ResourceManager.GetString("ReturnCodeSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to Authorize. We cannot authorize this account..
        /// </summary>
        internal static string ReturnCodeUnableToAuthorize {
            get {
                return ResourceManager.GetString("ReturnCodeUnableToAuthorize", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to invoke the Wine.com API service for the resource, &quot;{0}&quot;..
        /// </summary>
        internal static string WineApiServiceExceptionMessage {
            get {
                return ResourceManager.GetString("WineApiServiceExceptionMessage", resourceCulture);
            }
        }
    }
}
