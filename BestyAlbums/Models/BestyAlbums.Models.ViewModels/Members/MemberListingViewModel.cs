namespace BestyAlbums.Models.ViewModels.Members
{
    using Data.Models.Enums;

    public class MemberListingViewModel
    {
        public int Id { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string BirthDate { get; init; }

        public string Joined { get; init; }

        public string Left { get; init; }

        public Gender Gender { get; init; }

        public string ImageUrl { get; init; }

        public string Artist { get; init; }
    }
}