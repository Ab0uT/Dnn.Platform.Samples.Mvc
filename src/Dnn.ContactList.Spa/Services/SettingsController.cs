﻿// Copyright (c) DNN Software. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Net.Http;
using System.Web.Http;
using Dnn.ContactList.Spa.Components;
using Dnn.ContactList.Spa.Services.ViewModels;
using DotNetNuke.Security;
using DotNetNuke.Web.Api;

namespace Dnn.ContactList.Spa.Services
{
    /// <summary>
    /// ContentTypeController provides the Web Services to manage Data Types
    /// </summary>
    [SupportedModules("Dnn.ContactList.Spa")]
    [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
    public class SettingsController : DnnApiController
    {
        private readonly ISettingsService _setttingsService;

        /// <summary>
        /// Default Constructor constructs a new SettingsController
        /// </summary>
        public SettingsController()
        {
            _setttingsService = SettingsService.Instance;
        }

        /// <summary>
        /// The DeleteContact method deletes a single contact
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SaveSettings(SettingsViewModel settings)
        {
            _setttingsService.SaveFormEnabled(settings.IsFormEnabled, ActiveModule.ModuleID);

            var response = new
            {
                success = true
            };

            return Request.CreateResponse(response);
        }
    }
}