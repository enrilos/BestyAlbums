namespace BestyAlbums.Services.Contracts
{
    using Data.Models;
    using Data.Models.Enums;
    using Models.InputModels.Members;
    using System;
    using System.Collections.Generic;

    public interface IMemberService
    {
        int Add(string firstName, string lastName, DateTime birthdate, DateTime joined, DateTime? left, Gender gender, string imageUrl, Artist artist);

        IList<Member> GetAll();

        Member Get(int id);

        bool Exists(int id);

        void Edit(MemberEditModel model);
    }
}
