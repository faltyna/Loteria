namespace Loteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nagrodas",
                c => new
                    {
                        nagrodaId = c.Int(nullable: false, identity: true),
                        nagroda = c.String(),
                        Uczestnik_uczestnikId = c.Int(),
                    })
                .PrimaryKey(t => t.nagrodaId)
                .ForeignKey("dbo.Uczestniks", t => t.Uczestnik_uczestnikId)
                .Index(t => t.Uczestnik_uczestnikId);
            
            CreateTable(
                "dbo.Odpowiedzs",
                c => new
                    {
                        odpowiedzId = c.Int(nullable: false, identity: true),
                        tresc = c.String(),
                        poprawnoscOdpowiedzi = c.Boolean(nullable: false),
                        pytanieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.odpowiedzId)
                .ForeignKey("dbo.Pytanies", t => t.pytanieId, cascadeDelete: true)
                .Index(t => t.pytanieId);
            
            CreateTable(
                "dbo.Pytanies",
                c => new
                    {
                        pytanieId = c.Int(nullable: false, identity: true),
                        tresc = c.String(),
                    })
                .PrimaryKey(t => t.pytanieId);
            
            CreateTable(
                "dbo.Uczestniks",
                c => new
                    {
                        uczestnikId = c.Int(nullable: false, identity: true),
                        imie = c.String(),
                        nazwisko = c.String(),
                        pseudonim = c.String(),
                    })
                .PrimaryKey(t => t.uczestnikId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nagrodas", "Uczestnik_uczestnikId", "dbo.Uczestniks");
            DropForeignKey("dbo.Odpowiedzs", "pytanieId", "dbo.Pytanies");
            DropIndex("dbo.Odpowiedzs", new[] { "pytanieId" });
            DropIndex("dbo.Nagrodas", new[] { "Uczestnik_uczestnikId" });
            DropTable("dbo.Uczestniks");
            DropTable("dbo.Pytanies");
            DropTable("dbo.Odpowiedzs");
            DropTable("dbo.Nagrodas");
        }
    }
}
