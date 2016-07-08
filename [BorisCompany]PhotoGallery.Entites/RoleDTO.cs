namespace _BorisCompany_PhotoGallery.Entites
{
    public class RoleDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RoleDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
