namespace BestyAlbums.Services.Contracts
{
    using Data.Models.Enums;
    using Models.InputModels.Members;
    using Models.ViewModels.Members;
    using System;
    using System.Collections.Generic;

    public interface IMemberService
    {
        int Add(
            string firstName,
            string lastName,
            DateTime birthdate,
            DateTime joined,
            DateTime? left,
            Gender gender,
            string imageUrl,
            int artistId);

        IEnumerable<MemberListingViewModel> GetAll();

        EditMemberFormModel GetEditModel(int id);

        bool Exists(int id);

        void Delete(int id);

        void Edit(
            int id,
            string firstName,
            string lastName,
            DateTime birthDate,
            DateTime joined,
            DateTime? left,
            Gender gender,
            string imageUrl);
    }
}