﻿namespace GShop.Services.Actions;

using System.Threading.Tasks;

public interface IAction
{
    Task SendEmail(EmailModel model);
}
