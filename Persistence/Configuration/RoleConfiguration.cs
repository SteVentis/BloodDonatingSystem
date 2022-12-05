using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Hospital",
                    NormalizedName = "HOSPITAL"
                },
                new IdentityRole
                {
                    Name = "BloodDonationCenter",
                    NormalizedName = "BLOODDONATIONCENTER"
                },
                 new IdentityRole
                 {
                     Name = "BloodDonor",
                     NormalizedName = "BLOODDONOR"
                 },
                 new IdentityRole
                 {
                     Name = "Administrator",
                     NormalizedName = "ADMINISTRATOR"
                 });
        }
    }
}
