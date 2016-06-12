using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using SocialEventsWebApi.models;

namespace SocialEventsWebApi.Migrations
{
    [ContextType(typeof(SocialEventsAppContext))]
    partial class SocialEventsAppContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("SqlServer:DefaultSequenceName", "DefaultSequence")
                .Annotation("SqlServer:Sequence:.DefaultSequence", "'DefaultSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .Annotation("SqlServer:ValueGeneration", "Sequence");
            
            builder.Entity("SocialEventsWebApi.models.SocialEvent", b =>
                {
                    b.Property<int>("Id")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity);
                    
                    b.Property<string>("Content");
                    
                    b.Property<DateTime>("CreationDate");
                    
                    b.Property<DateTime>("EventDate");
                    
                    b.Property<string>("MapUrl");
                    
                    b.Property<string>("Title");
                    
                    b.Key("Id");
                });
        }
    }
}
