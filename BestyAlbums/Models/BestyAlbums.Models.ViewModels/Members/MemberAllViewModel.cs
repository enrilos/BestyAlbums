namespace BestyAlbums.Models.ViewModels.Members
{
    using Data.Models.Enums;

    public class MemberAllViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BirthDate { get; set; }

        public string Joined { get; set; }

        public string Left { get; set; }

        public Gender Gender { get; set; }

        public string ImageUrl { get; set; }

        public string Artist { get; set; }
    }
}
