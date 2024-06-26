namespace GShop.Context.Seeder;

using GShop.Context.Entities;

public class DemoHelper
{

    public IEnumerable<User> GetUsers = new List<User>
    {
        new User()
        {
            Uid = Guid.NewGuid(),
            Email = "user@mail.com",
            FirstName = "TestUser",
            CreatedGadgets = new List<Gadget>() 
            {
                new Gadget() 
                {
                    Uid = Guid.NewGuid(),
                    Name = "TestGadget",
                    Details = new GadgetDetails() 
                    {
                        Price = 1,
                        Description = "Cool Test Gadget"
                    }
                }
            }
        }
    };
}