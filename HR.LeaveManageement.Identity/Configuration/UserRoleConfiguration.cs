using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "dfb0abae-abc5-4e54-9d04-f19bb79f8654",
                    UserId = "9e224968-33e4-4652-b7b7-8574d048cdb9"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "069229c3-1d11-4564-8d96-45b04b1ee0f2",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );

        }
    }
}
