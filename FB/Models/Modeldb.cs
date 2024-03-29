namespace FB.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Modeldb : DbContext
    {
        // Your context has been configured to use a 'Modeldb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FB.Models.Modeldb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Modeldb' 
        // connection string in the application configuration file.
        public Modeldb()
            : base("name=Modeldb")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<FBPost> FBPosts { get; set; }
        public  virtual DbSet<Comment> Comments { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}