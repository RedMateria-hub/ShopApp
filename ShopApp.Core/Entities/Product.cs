using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Core.Entities;

public class Product : BaseEntity
{
    public string Type { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}
