﻿namespace GShop.api.Controllers;

public class UserRegisterRequestDTO
{

    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}