namespace GShop.Context.Seeder;

using GShop.Context.Entities;
using System.Net;

public class DemoHelper
{

    public IEnumerable<User> GetUsers = new List<User>
    {
        new User()
        {
            Id = Guid.NewGuid(),
            Email = "testUser@mail.com",
            PhoneNumber = "8 800 555 35 35",
            UserName = "TestName",
            CreatedGadgets = new List<Gadget>() 
            {
                new Gadget() 
                {
                    Uid = Guid.NewGuid(),
                    Title = "TestGadget",
                    Details = new GadgetDetails() 
                    {
                        Price = 1,
                        Description = "Cool Test Gadget"
                    },
                    Categories = new List<Category>()
                    {
                        new Category() 
                        {
                            Title = "TestCategory",
                        },
                        new Category()
                        {
                            Title = "TestCategory2",
                        }
                    }
                }

            }
        }
    };
}