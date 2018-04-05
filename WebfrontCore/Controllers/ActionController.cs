﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary;
using WebfrontCore.ViewModels;

namespace WebfrontCore.Controllers
{
    public class ActionController : BaseController
    {
        public IActionResult BanForm()
        {
            var info = new ActionInfo()
            {
                ActionButtonLabel = "Ban",
                Name = "Ban",
                Inputs = new List<InputInfo>()
                {
                    new InputInfo()
                    {
                      Name = "Reason",
                      Placeholder = ""
                    }
                },
                Action = "BanAsync"
            };

            return View("_ActionForm", info);
        }

        public async Task<IActionResult> BanAsync(int targetId, string Reason)
        {
            var server = Manager.GetServers().First();

            return await Task.FromResult(RedirectToAction("ExecuteAsync", "Console", new
            {
                serverId = server.GetHashCode(),
                command = $"!ban @{targetId} {Reason}"
            }));
        }

        public IActionResult UnbanForm()
        {
            var info = new ActionInfo()
            {
                ActionButtonLabel = "Unban",
                Name = "Unban",
                Inputs = new List<InputInfo>()
                {
                    new InputInfo()
                    {
                      Name = "Reason",
                      Placeholder = ""
                    }
                },
                Action = "UnbanAsync"
            };

            return View("_ActionForm", info);
        }

        public async Task<IActionResult> UnbanAsync(int targetId, string Reason)
        {
            var server = Manager.GetServers().First();

            return await Task.FromResult(RedirectToAction("ExecuteAsync", "Console", new
            {
                serverId = server.GetHashCode(),
                command = $"!unban @{targetId} {Reason}"
            }));
        }

        public IActionResult LoginForm()
        {
            var login = new ActionInfo()
            {
                ActionButtonLabel = "Login",
                Name = "Login",
                Inputs = new List<InputInfo>()
                {
                    new InputInfo()
                    {
                        Name = "User ID"
                    },
                    new InputInfo()
                    {
                        Name = "Password",
                        Type = "password",
                    }
                },
                Action = "Login"
            };

            return View("_ActionForm", login);
        }

        public IActionResult Login(int userId, string password)
        {
            return RedirectToAction("Login", "Account", new { userId, password });
        }
    }
}
