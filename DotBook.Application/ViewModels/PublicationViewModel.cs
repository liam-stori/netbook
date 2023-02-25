﻿using DotBook.Core.Entities;

namespace DotBook.Application.ViewModels
{
    public class PublicationViewModel
    {
        public PublicationViewModel(string content, DateTime createdAt, int idUser, List<PublicationComment> comments)
        {
            Content = content;
            CreatedAt = createdAt;
            IdUser = idUser;
            Comments = comments;
        }

        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int IdUser { get; private set; }
        public List<PublicationComment> Comments { get; private set; }
    }
}