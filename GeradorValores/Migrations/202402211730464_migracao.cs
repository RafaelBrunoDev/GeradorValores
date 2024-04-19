namespace GeradorValores.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_funcionarios",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.tbl_funcionarios_valor_hora",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        id_funcionario = c.Int(nullable: false),
                        valor_hora = c.Decimal(precision: 18, scale: 2),
                        ano = c.Int(),
                        mes = c.Int(),
                        ativo = c.Boolean(),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.tbl_funcionarios", t => t.id_funcionario, cascadeDelete: true)
                .Index(t => t.id_funcionario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_funcionarios_valor_hora", "id_funcionario", "dbo.tbl_funcionarios");
            DropIndex("dbo.tbl_funcionarios_valor_hora", new[] { "id_funcionario" });
            DropTable("dbo.tbl_funcionarios_valor_hora");
            DropTable("dbo.tbl_funcionarios");
        }
    }
}
