using System.ComponentModel.DataAnnotations;

namespace GShop.Context.Entities;

public class GadgetImage
{
    [Key]
    public int Id { get; set; }
    public int GadgetId { get; set; }
    public virtual Gadget Gadget { get; set; }
    public byte[] Image { get; set; } = default!;
}
