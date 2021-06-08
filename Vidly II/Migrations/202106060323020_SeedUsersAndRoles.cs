namespace Vidly_II.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'826eb37c-4c7a-423e-90db-730c11b2ceee', N'ali@live.com', 0, N'ACUMmrz338OW1Vi+PkH3hmXT/pavaD3xnUO/Ul/lTy9YM4yjn6DA3P+BfO5TjMF6eA==', N'8da3d7fd-9e66-4023-845e-a24099a0e16a', NULL, 0, 0, NULL, 1, 0, N'ali@live.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fea5c608-0ed3-44bb-ba04-ae87948fc21f', N'admin@vidly.com', 0, N'AETnz7gk4kpU5BAu4xmk9AxoLtnVPhMgsG1068vy5H++A68HjmBreb+uBOZUiT/3BQ==', N'2fb6df79-5d69-4912-a52a-fe46b036150a', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'00bae0f6-03c7-48ea-b306-20f89ff3dcdb', N'edit-movies')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fea5c608-0ed3-44bb-ba04-ae87948fc21f', N'00bae0f6-03c7-48ea-b306-20f89ff3dcdb')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
