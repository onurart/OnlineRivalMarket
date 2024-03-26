using OnlineRivalMarket.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Domain.AppEntities.Identity
{
    public sealed class AppUserRole : Entity
    {
        public AppUserRole()
        {

        }
        public AppUserRole(string id, string roleid, string userid) : base(id)
        {
            RoleId = roleid;
            UserId = userid;
        }
        [ForeignKey("AppRole")]
        public string RoleId { get; set; }
        public AppRole AppRole { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser? User { get; set; }
    }
}
