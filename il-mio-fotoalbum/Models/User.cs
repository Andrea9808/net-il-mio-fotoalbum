using Microsoft.AspNetCore.Identity;

namespace il_mio_fotoalbum.Models
{
    public class User : IdentityUser
    {
        List<Foto> Fotos = new List<Foto>();
        public User() {}
    }
}
