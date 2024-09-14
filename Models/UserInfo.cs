using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLoginApp.Models;

public record UserInfo(
    int id,
    string username,
    string email,
    string firstName,
    string lastName,
    string gender,
    string image,
    string token,
    string refreshToken);
