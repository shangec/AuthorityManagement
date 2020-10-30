
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/28/2020 13:16:26
-- Generated from EDMX file: D:\Study\AuthorityManagement\AuthorityManagement.Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Test];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserInfo_R_UserInfo_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_UserInfo_Role] DROP CONSTRAINT [FK_UserInfo_R_UserInfo_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_Role_R_UserInfo_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_UserInfo_Role] DROP CONSTRAINT [FK_Role_R_UserInfo_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoR_UserInfo_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_UserInfo_ActionInfo] DROP CONSTRAINT [FK_UserInfoR_UserInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionInfo_R_UserInfo_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_UserInfo_ActionInfo] DROP CONSTRAINT [FK_ActionInfo_R_UserInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfo_ActionGroup_UserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfo_ActionGroup] DROP CONSTRAINT [FK_UserInfo_ActionGroup_UserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfo_ActionGroup_ActionGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfo_ActionGroup] DROP CONSTRAINT [FK_UserInfo_ActionGroup_ActionGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionGroup_ActionInfo_ActionGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionGroup_ActionInfo] DROP CONSTRAINT [FK_ActionGroup_ActionInfo_ActionGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionGroup_ActionInfo_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionGroup_ActionInfo] DROP CONSTRAINT [FK_ActionGroup_ActionInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Role_ActionGroup_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Role_ActionGroup] DROP CONSTRAINT [FK_Role_ActionGroup_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_Role_ActionGroup_ActionGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Role_ActionGroup] DROP CONSTRAINT [FK_Role_ActionGroup_ActionGroup];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[ActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[ActionGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionGroup];
GO
IF OBJECT_ID(N'[dbo].[R_UserInfo_Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_UserInfo_Role];
GO
IF OBJECT_ID(N'[dbo].[R_UserInfo_ActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_UserInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[UserInfo_ActionGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo_ActionGroup];
GO
IF OBJECT_ID(N'[dbo].[ActionGroup_ActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionGroup_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[Role_ActionGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role_ActionGroup];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UName] nvarchar(32)  NULL,
    [Pwd] nvarchar(16)  NULL,
    [Phone] nvarchar(11)  NULL,
    [Mail] nvarchar(max)  NULL,
    [SubTime] datetime  NULL,
    [LastModifiedOn] nvarchar(max)  NULL,
    [DelFlag] bit  NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(max)  NULL,
    [RoleType] int  NULL,
    [DelFlag] bit  NOT NULL,
    [SubTime] datetime  NULL
);
GO

-- Creating table 'ActionInfo'
CREATE TABLE [dbo].[ActionInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RequestUrl] nvarchar(max)  NULL,
    [RequestHttpType] int  NULL,
    [ActionName] int  NULL,
    [SubTime] datetime  NULL,
    [ActionType] int  NULL
);
GO

-- Creating table 'ActionGroup'
CREATE TABLE [dbo].[ActionGroup] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupName] nvarchar(max)  NULL,
    [DelFlag] datetime  NOT NULL,
    [GroupType] int  NOT NULL
);
GO

-- Creating table 'R_UserInfo_Role'
CREATE TABLE [dbo].[R_UserInfo_Role] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserInfoID] int  NULL,
    [RoleID] int  NULL,
    [SubTime] datetime  NULL,
    [UserInfoID1] int  NOT NULL,
    [Role_ID] int  NOT NULL
);
GO

-- Creating table 'R_UserInfo_ActionInfo'
CREATE TABLE [dbo].[R_UserInfo_ActionInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserInfoID] int  NULL,
    [ActionInfoID] int  NULL,
    [HasPermation] bit  NULL,
    [UserInfoID1] int  NOT NULL,
    [ActionInfo_ID] int  NOT NULL
);
GO

-- Creating table 'UserInfo_ActionGroup'
CREATE TABLE [dbo].[UserInfo_ActionGroup] (
    [UserInfo_ID] int  NOT NULL,
    [ActionGroup_ID] int  NOT NULL
);
GO

-- Creating table 'ActionGroup_ActionInfo'
CREATE TABLE [dbo].[ActionGroup_ActionInfo] (
    [ActionGroup_ID] int  NOT NULL,
    [ActionInfo_ID] int  NOT NULL
);
GO

-- Creating table 'Role_ActionGroup'
CREATE TABLE [dbo].[Role_ActionGroup] (
    [Role_ID] int  NOT NULL,
    [ActionGroup_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ActionInfo'
ALTER TABLE [dbo].[ActionInfo]
ADD CONSTRAINT [PK_ActionInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ActionGroup'
ALTER TABLE [dbo].[ActionGroup]
ADD CONSTRAINT [PK_ActionGroup]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'R_UserInfo_Role'
ALTER TABLE [dbo].[R_UserInfo_Role]
ADD CONSTRAINT [PK_R_UserInfo_Role]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'R_UserInfo_ActionInfo'
ALTER TABLE [dbo].[R_UserInfo_ActionInfo]
ADD CONSTRAINT [PK_R_UserInfo_ActionInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [UserInfo_ID], [ActionGroup_ID] in table 'UserInfo_ActionGroup'
ALTER TABLE [dbo].[UserInfo_ActionGroup]
ADD CONSTRAINT [PK_UserInfo_ActionGroup]
    PRIMARY KEY CLUSTERED ([UserInfo_ID], [ActionGroup_ID] ASC);
GO

-- Creating primary key on [ActionGroup_ID], [ActionInfo_ID] in table 'ActionGroup_ActionInfo'
ALTER TABLE [dbo].[ActionGroup_ActionInfo]
ADD CONSTRAINT [PK_ActionGroup_ActionInfo]
    PRIMARY KEY CLUSTERED ([ActionGroup_ID], [ActionInfo_ID] ASC);
GO

-- Creating primary key on [Role_ID], [ActionGroup_ID] in table 'Role_ActionGroup'
ALTER TABLE [dbo].[Role_ActionGroup]
ADD CONSTRAINT [PK_Role_ActionGroup]
    PRIMARY KEY CLUSTERED ([Role_ID], [ActionGroup_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfoID1] in table 'R_UserInfo_Role'
ALTER TABLE [dbo].[R_UserInfo_Role]
ADD CONSTRAINT [FK_UserInfo_R_UserInfo_Role]
    FOREIGN KEY ([UserInfoID1])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfo_R_UserInfo_Role'
CREATE INDEX [IX_FK_UserInfo_R_UserInfo_Role]
ON [dbo].[R_UserInfo_Role]
    ([UserInfoID1]);
GO

-- Creating foreign key on [Role_ID] in table 'R_UserInfo_Role'
ALTER TABLE [dbo].[R_UserInfo_Role]
ADD CONSTRAINT [FK_Role_R_UserInfo_Role]
    FOREIGN KEY ([Role_ID])
    REFERENCES [dbo].[Role]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Role_R_UserInfo_Role'
CREATE INDEX [IX_FK_Role_R_UserInfo_Role]
ON [dbo].[R_UserInfo_Role]
    ([Role_ID]);
GO

-- Creating foreign key on [UserInfoID1] in table 'R_UserInfo_ActionInfo'
ALTER TABLE [dbo].[R_UserInfo_ActionInfo]
ADD CONSTRAINT [FK_UserInfoR_UserInfo_ActionInfo]
    FOREIGN KEY ([UserInfoID1])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoR_UserInfo_ActionInfo'
CREATE INDEX [IX_FK_UserInfoR_UserInfo_ActionInfo]
ON [dbo].[R_UserInfo_ActionInfo]
    ([UserInfoID1]);
GO

-- Creating foreign key on [ActionInfo_ID] in table 'R_UserInfo_ActionInfo'
ALTER TABLE [dbo].[R_UserInfo_ActionInfo]
ADD CONSTRAINT [FK_ActionInfo_R_UserInfo_ActionInfo]
    FOREIGN KEY ([ActionInfo_ID])
    REFERENCES [dbo].[ActionInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfo_R_UserInfo_ActionInfo'
CREATE INDEX [IX_FK_ActionInfo_R_UserInfo_ActionInfo]
ON [dbo].[R_UserInfo_ActionInfo]
    ([ActionInfo_ID]);
GO

-- Creating foreign key on [UserInfo_ID] in table 'UserInfo_ActionGroup'
ALTER TABLE [dbo].[UserInfo_ActionGroup]
ADD CONSTRAINT [FK_UserInfo_ActionGroup_UserInfo]
    FOREIGN KEY ([UserInfo_ID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ActionGroup_ID] in table 'UserInfo_ActionGroup'
ALTER TABLE [dbo].[UserInfo_ActionGroup]
ADD CONSTRAINT [FK_UserInfo_ActionGroup_ActionGroup]
    FOREIGN KEY ([ActionGroup_ID])
    REFERENCES [dbo].[ActionGroup]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfo_ActionGroup_ActionGroup'
CREATE INDEX [IX_FK_UserInfo_ActionGroup_ActionGroup]
ON [dbo].[UserInfo_ActionGroup]
    ([ActionGroup_ID]);
GO

-- Creating foreign key on [ActionGroup_ID] in table 'ActionGroup_ActionInfo'
ALTER TABLE [dbo].[ActionGroup_ActionInfo]
ADD CONSTRAINT [FK_ActionGroup_ActionInfo_ActionGroup]
    FOREIGN KEY ([ActionGroup_ID])
    REFERENCES [dbo].[ActionGroup]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ActionInfo_ID] in table 'ActionGroup_ActionInfo'
ALTER TABLE [dbo].[ActionGroup_ActionInfo]
ADD CONSTRAINT [FK_ActionGroup_ActionInfo_ActionInfo]
    FOREIGN KEY ([ActionInfo_ID])
    REFERENCES [dbo].[ActionInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionGroup_ActionInfo_ActionInfo'
CREATE INDEX [IX_FK_ActionGroup_ActionInfo_ActionInfo]
ON [dbo].[ActionGroup_ActionInfo]
    ([ActionInfo_ID]);
GO

-- Creating foreign key on [Role_ID] in table 'Role_ActionGroup'
ALTER TABLE [dbo].[Role_ActionGroup]
ADD CONSTRAINT [FK_Role_ActionGroup_Role]
    FOREIGN KEY ([Role_ID])
    REFERENCES [dbo].[Role]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ActionGroup_ID] in table 'Role_ActionGroup'
ALTER TABLE [dbo].[Role_ActionGroup]
ADD CONSTRAINT [FK_Role_ActionGroup_ActionGroup]
    FOREIGN KEY ([ActionGroup_ID])
    REFERENCES [dbo].[ActionGroup]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Role_ActionGroup_ActionGroup'
CREATE INDEX [IX_FK_Role_ActionGroup_ActionGroup]
ON [dbo].[Role_ActionGroup]
    ([ActionGroup_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------