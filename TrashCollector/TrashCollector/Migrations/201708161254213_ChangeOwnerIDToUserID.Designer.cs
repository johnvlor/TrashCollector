// <auto-generated />
namespace TrashCollector.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class ChangeOwnerIDToUserID : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(ChangeOwnerIDToUserID));
        
        string IMigrationMetadata.Id
        {
            get { return "201708161254213_ChangeOwnerIDToUserID"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}