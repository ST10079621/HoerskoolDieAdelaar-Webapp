using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HoerskoolDieAdelaar.Areas.Identity.Data;

// Add profile data for application users by adding properties to the HoerskoolDieAdelaarUser class
public class HoerskoolDieAdelaarUser : IdentityUser
{

    //Firstname
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }

    //Lastname
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }
}

