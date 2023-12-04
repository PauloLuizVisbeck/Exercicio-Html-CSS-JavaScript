namespace AgendaMVC.Dados
{
    public class Db
    {
        public static List<Models.Contato> contatos = new()
        {
            /*new Models.Contato()
                    {   Id= 1,
                        Nome="maria",
                        Email="maria@gmail.com",
                        Fone="(47)9087-1234"
                    }*/
        };

        public static List<Models.Compromisso> compromissos = new()
        {
            /*new Models.Compromisso()
              { Id= 1, Data=DateTime.Now, Descricao="" },
                /*Contato= new Models.Contato()
                     {   Id= 1,
                         Nome="maria",
                         Email="maria@gmail.com",
                         Fone="(47)9087-1234"
                     }
                }*/
        };
    }
}
