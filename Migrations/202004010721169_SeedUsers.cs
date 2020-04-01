namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5dc3fc48-fc10-451c-806d-e6cf3a2e7e5e', N'guest@vidly.com', 0, N'AO7jGIkwMilSp0NWfgjpJZpnLjq6D1MLn+EsgU0mS4Pwdr53Vh106Bs1HEBk8DrwfQ==', N'd152f904-49c2-4fff-9c59-af2e43509a2b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b404e6c8-0f3f-4f28-86e0-b10893fb287c', N'admin@vidly.com', 0, N'AFiJRmmrpi/vDDlqUt0kxgQNAN5v6IIhCFdKLW/hqw6mSpGb/YvJc/W20x1qnmy6KQ==', N'3590ec5c-af4e-4ac9-ac5d-3e073f48a2fb', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f1cc97ff-9ca2-445b-be11-70a48e4ac7f6', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b404e6c8-0f3f-4f28-86e0-b10893fb287c', N'f1cc97ff-9ca2-445b-be11-70a48e4ac7f6')
");
            
        }
        
        public override void Down()
        {
        }
    }
}
