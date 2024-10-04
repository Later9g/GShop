using System.ComponentModel.DataAnnotations;

namespace GShop.Context.Entities;

public class GadgetImage : BaseEntity
{
    public int GadgetId { get; set; }
    public virtual Gadget Gadget { get; set; }
    public byte[] Image { get; set; } = default!;
}
