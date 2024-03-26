﻿using OnlineRivalMarket.Domain.Abstractions;
using OnlineRivalMarket.Domain.AppEntities.Identity;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineRivalMarket.Domain.AppEntities
{
    public sealed class MainRoleAndUserRelationship : Entity
    {
        public MainRoleAndUserRelationship(){}
        public MainRoleAndUserRelationship(string id, string userId, string mainRoleId) : base(id)
        {
            UserId = userId;
            MainRoleId = mainRoleId;
        }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser? User { get; set; }
        [ForeignKey("MainRole")]
        public string MainRoleId { get; set; }
        public MainRole? MainRole { get; set; }
    }
}
